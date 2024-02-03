using Profiler.Tests;
using Tests.Common;
using Tests.Common.Exceptions;
using Xunit;
using Xunit.Abstractions;


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


        [SkippableFact(typeof(RuntimeNotSupportedException))]
        public void TransitionsTest()
        {
            Assert.Equal(100, Transitions.ExecuteTest(NoArgs, _outputHelper));
        }


        [SkippableFact(typeof(RuntimeNotSupportedException))]
        public void GC()
        {
            Assert.Equal(100, GCTests.ExecuteTest(NoArgs, _outputHelper));
        }


        [SkippableFact(typeof(RuntimeNotSupportedException))]
        public void GCAllocate()
        {
            Assert.Equal(100, GCAllocateTests.ExecuteTest(NoArgs, _outputHelper));
        }


        [SkippableFact(typeof(RuntimeNotSupportedException))]
        public void GCBasic()
        {
            Assert.Equal(100, GCBasicTests.Main(NoArgs));
        }


        [SkippableFact(typeof(RuntimeNotSupportedException))]
        public void Assembly()
        {
            Assert.Equal(100, ALCTests.ExecuteTest(NoArgs, _outputHelper));
        }


        [SkippableFact(typeof(RuntimeNotSupportedException))]
        public void Inlining()
        {
            Assert.Equal(100, InliningTest.ExecuteTest(NoArgs, _outputHelper));
        }

        [SkippableFact(typeof(RuntimeNotSupportedException))]
        public void Handles()
        {
            Assert.Equal(100, HandlesTests.ExecuteTest(NoArgs, _outputHelper));
        }
    }
}