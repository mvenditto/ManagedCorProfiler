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

namespace CorProf.Generator
{
    [Generator]
    public class Generator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var trees = context.Compilation.SyntaxTrees.Where(
                st => st.GetRoot()
                .DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .Any(p => p.DescendantNodes().OfType<AttributeSyntax>().Any()));

            //var tree = trees.FirstOrDefault();

            //if (tree == null) return;

            var profilerClasses = trees.SelectMany(tree =>
            {
                var profilerClasses = tree
                    .GetRoot()
                    .DescendantNodes()
                    .OfType<ClassDeclarationSyntax>();

                return profilerClasses;
            });

            var profilers = new Dictionary<string, string>();

            foreach (var profilerClass in profilerClasses)
            {
                var semanticModel = context.Compilation.GetSemanticModel(profilerClass.SyntaxTree);

                var attribute = profilerClass.DescendantNodes()
                    .OfType<AttributeSyntax>()
                    .FirstOrDefault(asy => semanticModel.GetTypeInfo(
                        asy, context.CancellationToken).Type?.Name == "ProfilerCallbackAttribute");

                if (attribute == null)
                {
                    continue;
                }

                var profilerGuid = attribute.ArgumentList?
                    .Arguments
                    .FirstOrDefault()?
                    .NormalizeWhitespace()
                    .ToFullString()
                    .ToUpper();

                if (profilerGuid == null)
                {
                    continue;
                }

                Console.WriteLine($"{profilerGuid} -> {profilerClass.ToFullString()}");

                // generate the Guid attribute for the profiler type using the guid
                // provided to ProfilerCallbackAttribute
                var name = SyntaxFactory.ParseName("Guid");
                var arguments = SyntaxFactory.ParseAttributeArgumentList($"(\"{profilerGuid}\")");
                var guidAttribute = SyntaxFactory.Attribute(name, arguments); 
                var attributeList = new SeparatedSyntaxList<AttributeSyntax>();
                attributeList = attributeList.Add(guidAttribute);
                var list = SyntaxFactory.AttributeList(attributeList);
                profilerClass.AttributeLists.Add(list);


                if (profilerClass == null)
                {
                    return;
                }

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

                profilers.Add(profilerGuid, fullNamespace + "." + className);
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
