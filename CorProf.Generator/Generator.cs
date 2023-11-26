using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Scriban;
using CorProf.Generators;
using System;
using System.Threading;
using System.IO;
using System.Text;

namespace CorProf.Generator
{
    [Generator]
    public class Generator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var trees = context.Compilation.SyntaxTrees.ToArray();
            var profilers = new Dictionary<string, string>();

            for (var i = 0; i < trees.Length; i++)
            {
                var tree = trees[i];
                var root = tree.GetRoot();
                var semanticModel = context.Compilation.GetSemanticModel(tree);

                IEnumerable<(ClassDeclarationSyntax, AttributeSyntax)> profilerDecls = root.DescendantNodes()
                     .OfType<ClassDeclarationSyntax>()
                     .Select(cls =>
                     {
                         var profilerAttr = cls.DescendantNodes()
                             .OfType<AttributeSyntax>()
                             .FirstOrDefault(attr => semanticModel.GetTypeInfo(
                                 attr, context.CancellationToken).Type?.Name == "ProfilerCallbackAttribute");

                         return (cls, profilerAttr);
                     })
                     .Where(x => x.profilerAttr != null);

                foreach (var (profilerClass, profilerAttr) in profilerDecls)
                {
                    var profilerGuid = profilerAttr.ArgumentList?
                        .Arguments
                        .FirstOrDefault()?
                        .NormalizeWhitespace()
                        .ToFullString()
                        .ToUpper();

                    if (profilerGuid == null)
                    {
                        continue;
                    }

                    // generate the Guid attribute for the profiler type using the guid provided to ProfilerCallbackAttribute
                    var name = SyntaxFactory.ParseName("Guid");
                    var arguments = SyntaxFactory.ParseAttributeArgumentList($"(\"{profilerGuid}\")");
                    var guidAttribute = SyntaxFactory.Attribute(name, arguments);
                    var attributeList = new SeparatedSyntaxList<AttributeSyntax>();
                    attributeList = attributeList.Add(guidAttribute);
                    var list = SyntaxFactory.AttributeList(attributeList);
                    profilerClass.AttributeLists.Add(list);

                    var profilerClassSymbol = semanticModel.GetDeclaredSymbol(profilerClass);

                    if (profilerClassSymbol == null)
                    {
                        return;
                    }

                    var className = profilerClassSymbol.Name;

                    var ns = profilerClassSymbol.ContainingNamespace;

                    var namespaces = new List<string>();
                    do
                    {
                        namespaces.Insert(0, ns.Name);
                        ns = ns?.ContainingNamespace;
                    }
                    while (ns != null);

                    var fullNamespace = namespaces.Aggregate((a, b) => $"{a}.{b}");

                    if (fullNamespace.StartsWith("."))
                    {
                        fullNamespace = fullNamespace.Substring(1);
                    }

    					/*
                    var x = GenerateProfilerProxy(semanticModel, profilerClass, context.CancellationToken);

                    if (!string.IsNullOrEmpty(x))
                    {
                        var guid = new Guid(profilerGuid.Substring(1, profilerGuid.Length - 2)).ToString("N");
                        var proxyClassName = className + "_" + guid;
                        var source = """""";
                        var proxyDef = $"";
                    }
    					*/
                    profilers.Add(profilerGuid, fullNamespace + "." + className);
                }
            }

            var templateSource = Helpers.GetEmbeddedContent("DllEntryPointExports.sbncs");

            var template = Template.Parse(templateSource);

            var source = template.Render(new
            {
                ProfilerNamespace = "DllExports",
                ProfilersMap = profilers
            });

            context.AddSource($"DllEntryPointExports.g.cs", source);
        }

        private static string? GenerateProfilerProxy(
            SemanticModel semanticModel,
            ClassDeclarationSyntax profilerClass,
            CancellationToken cancellationToken)
        {
            var profilerMethods = profilerClass.DescendantNodes()
                    .OfType<MethodDeclarationSyntax>()
                    .Where(m => m.DescendantNodes()
                        .Any(p => p.DescendantNodes().OfType<AttributeSyntax>().Any()))
                    .ToList();

            var sb = new StringBuilder();

            foreach (var method in profilerMethods)
            {
                var shutdownGuardAttr = method.DescendantNodes()
                   .OfType<AttributeSyntax>()
                   .FirstOrDefault(a => a.ToString() == "ShutdownGuard");

                if (shutdownGuardAttr == default)
                {
                    continue;
                }

                var methodSymbol = semanticModel.GetDeclaredSymbol(method, cancellationToken);

                if (methodSymbol == null)
                {
                    continue;
                }

                var returnType = methodSymbol.ReturnType.Name;
                var accessModifier = methodSymbol.DeclaredAccessibility.ToString();
                var methodName = methodSymbol.Name;

                var parametersList = method.DescendantNodes()
                    .OfType<ParameterListSyntax>()
                    .FirstOrDefault();

                var parameters = parametersList
                    .DescendantNodes()
                    .OfType<ParameterSyntax>();

                var parameterNames = parameters.Any()
                    ? parameters
                        .Select(p => p.Identifier.Text)
                        .Aggregate((p1, p2) => p1 + "," + p2)
                    : string.Empty;

                sb.AppendLine($"public override {returnType} {methodName}{parametersList}");
                sb.AppendLine("{");
                sb.AppendLine("    using(var shutdownGuard = new ShutdownGuard())");
                sb.AppendLine("    {");
                sb.AppendLine("        if (ShutdownGuard.HasShutdownStarted()) return 0;");
                sb.AppendLine($"       int hr = base.{methodName}({parameterNames});");
                sb.AppendLine("        return hr;");
                sb.AppendLine("    }");
                sb.AppendLine("}");
            }

            return sb.ToString();
        }

        private static SyntaxNode InjectShutdownGuards(
            SyntaxNode root,
            SemanticModel semanticModel,
            ClassDeclarationSyntax profilerClass,
            CancellationToken cancellationToken)
        {
            var profilerMethods = profilerClass.DescendantNodes()
                    .OfType<MethodDeclarationSyntax>()
                    .Where(m => m.DescendantNodes()
                        .Any(p => p.DescendantNodes().OfType<AttributeSyntax>().Any()))
                    .ToList();

            SyntaxNode root_ = root;

            foreach (var method in profilerMethods)
            {
                if (method?.Body?.Statements.Count == 0) continue;

                var shutdownGuardAttr = method.DescendantNodes()
                    .OfType<AttributeSyntax>()
                    .FirstOrDefault(a => a.ToString() == "ShutdownGuard");

                if (shutdownGuardAttr == default)
                {
                    continue;
                }

                var shutdownGuard = SyntaxFactory.ParseStatement("using var _ = new ShutdownGuard();");
                var checkShutdownStarted = SyntaxFactory.ParseStatement("if (ShutdownGuard.HasShutdownStarted()) return 0;");

                var newMethod = method.InsertNodesBefore(
                    method.Body!.Statements.First(), 
                    new List<SyntaxNode> { shutdownGuard, checkShutdownStarted });

                root_ = root_.ReplaceNode(method, newMethod);
            }

            return root_;
        }

        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif
        }
    }
}
