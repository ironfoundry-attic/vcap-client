namespace IronFoundry.VcapClient.Test
{
    using System;
    using Xunit;

    public class DummyTests
    {
        [Fact]
        public void Initial_Test()
        {
            Assert.True(Environment.ProcessorCount > 0);
        }
    }
}