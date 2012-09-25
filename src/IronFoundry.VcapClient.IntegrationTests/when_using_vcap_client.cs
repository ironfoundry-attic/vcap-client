namespace IronFoundry.VcapClient.IntegrationTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class when_using_vcap_client
    {
        // This is a real test account specifically for this integration testing lib.
        protected string Username = "test-email@tier3.com";
        protected string Password = "test123!";
        protected Uri GoodUri = new Uri("http://api.ironfoundry.me");
        protected Uri FqdnUri = new Uri("http://integrationtests.ironfoundry.me");

        [Test]
        public void should_find_active_cloud()
        {
            var cloudActive = new VcapClient(GoodUri.ToString());
            cloudActive.Login(Username, Password);
            var cloudInfo = cloudActive.GetInfo();
            cloudInfo.Name.Should().NotBeNull();
        }

        [Test]
        public void should_pull_account_and_verify_nonadmin_user()
        {
            var cloudActive = new VcapClient(GoodUri.ToString());
            cloudActive.Login(Username, Password);
            var cloudInfo = cloudActive.GetUser(Username);
            cloudInfo.Admin.Should().BeFalse();
        }

        [Test]
        public void should_have_correct_target_uri()
        {
            var cloudActive = new VcapClient(GoodUri.ToString());
            cloudActive.Login(Username, Password);
            cloudActive.Target(GoodUri.ToString());
            var designatedUri = new Uri(cloudActive.CurrentUri);
            designatedUri.Should().Be(GoodUri.ToString());
        }
    }
}