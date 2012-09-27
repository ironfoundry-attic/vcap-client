using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace IronFoundry.VcapClient.Tests
{
    [TestFixture]
   public class when_using_vcap_client
    {
        protected VcapClient CloudActive;

        [TestFixtureSetUp]
        public void with_known_good_cloud_target()
        {
            var userHelper = Substitute.For<IUserHelper>();
            userHelper.Login(FakeAccountInformation.Username, FakeAccountInformation.Password);
        }

        [Test]
        public void should_create_vcap_client_with_uri()
        {
            CloudActive = new VcapClient(FakeAccountInformation.GoodUri.ToString());
            CloudActive.Should().NotBeNull();
        }
    }

    public static class FakeAccountInformation
    {
        // This is a real test account specifically for this integration testing lib.
        public const string Username = "fakeemail@fake.com";
        public const string Password = "fakepassword";
        public static readonly Uri GoodUri = new Uri("http://api.fake.me");
        public static readonly Uri FqdnUri = new Uri("http://integrationtests.fake.me");
        public const string TestAppToPush = @"\TestAppToPush";
        public const string TestApplicationName = "integration-test";
    }
}
