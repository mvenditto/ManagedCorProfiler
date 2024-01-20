using Profiler.Tests;
using System.Runtime.InteropServices;
using Tests.Common;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Tests
{
    public class ProfilersTest
    {
        private readonly IOutputHelper _outputHelper;

        private static readonly string[] NoArgs = [];

        class OutputHelper : IOutputHelper
        {
            private readonly ITestOutputHelper _testOutputHelper;

            public OutputHelper(ITestOutputHelper testOutputHelper)
            {
                _testOutputHelper = testOutputHelper;
            }

            public void WriteLine(string message)
            {
                _testOutputHelper.WriteLine(message);
            }

            public void WriteLine(string format, params object[] args)
            {
                _testOutputHelper.WriteLine(format, args);
            }
        }

        public ProfilersTest(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = new OutputHelper(testOutputHelper);
        }

        [Fact]
        public void TransitionsTest()
        {
            Assert.Equal(100, Transitions.ExecuteTest(NoArgs, _outputHelper));
        }

        [Fact]
        public void GC()
        {
            Assert.Equal(100, GCTests.ExecuteTest(NoArgs, _outputHelper));
        }

        [Fact]
        public void GCAllocate()
        {
            Assert.Equal(100, GCAllocateTests.ExecuteTest(NoArgs, _outputHelper));
        }

        [Fact]
        public void GCBasic()
        {
            Assert.Equal(100, GCBasicTests.Main(NoArgs));
        }
        
        [Fact]
        public void Assembly()
        {
            Assert.Equal(100, ALCTests.ExecuteTest(NoArgs, _outputHelper));
        }

        [Fact]
        public void Inlining()
        {
            Assert.Equal(100, InliningTest.ExecuteTest(NoArgs, _outputHelper));
        }

        [Fact]
        public void Handles()
        {
            Assert.Equal(100, HandlesTests.ExecuteTest(NoArgs, _outputHelper));
        }
    }
}