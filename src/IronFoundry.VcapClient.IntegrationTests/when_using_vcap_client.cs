namespace IronFoundry.VcapClient.IntegrationTests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class when_using_vcap_client
    {
        protected VcapClient CloudActive;

        [TestFixtureSetUp]
        public void with_known_good_cloud_target()
        {
            CloudActive = new VcapClient(TestAccountInformation.GoodUri.ToString());
            CloudActive.Login(
                TestAccountInformation.Username,
                TestAccountInformation.Password);
        }

        [Test]
        public void should_find_active_cloud()
        {
            CloudActive.GetInfo().Name.Should().NotBeNull();
        }

        [Test]
        public void should_pull_account_and_verify_nonadmin_user()
        {
             CloudActive.GetUser(TestAccountInformation.Username).Admin.Should().BeFalse();
        }

        [Test]
        public void should_have_correct_target_uri()
        {
            CloudActive.Target(TestAccountInformation.GoodUri.ToString());
            var designatedUri = new Uri(CloudActive.CurrentUri);
            designatedUri.Should().Be(TestAccountInformation.GoodUri.ToString());
        }
    }
}