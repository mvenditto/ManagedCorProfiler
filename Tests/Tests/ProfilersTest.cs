using Profiler.Tests;
using Xunit;

namespace Tests
{
    public class ProfilersTest
    {
        private static readonly string[] NoArgs = { };

        [Fact]
        public void TransitionsTest()
        {
            Assert.Equal(100, Transitions.Main(NoArgs));
        }

        [Fact]
        public void GC()
        {
            Assert.Equal(100, GCTests.Main(NoArgs));
        }

        [Fact]
        public void GCAllocate()
        {
            Assert.Equal(100, GCAllocateTests.Main(NoArgs));
        }

        [Fact]
        public void GCBasic()
        {
            Assert.Equal(100, GCBasicTests.Main(NoArgs));
        }
    }
}