using System;
using FluentAssertions;
using NUnit.Framework;

namespace IronFoundry.VcapClient.IntegrationTests
{
    [TestFixture]
    public class when_using_vcap_client
    {
        // This is a real test account specifically for this integration testing lib.
        protected string Username = "test-email@tier3.com";
        protected string Password = "test123!";
        protected Uri GoodUri = new Uri("http://api.ironfoundry.me");

        [Test]
        public void should_find_active_cloud()
        {
            var cloudActive = new VcapClient(GoodUri.ToString());
            cloudActive.Login(Username, Password);
            var cloudInfo = cloudActive.GetInfo();
            cloudInfo.Name.Should().NotBeNull();
        }
    }
}