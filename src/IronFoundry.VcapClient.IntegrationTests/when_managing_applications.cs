
using System.IO;
using FluentAssertions;

namespace IronFoundry.VcapClient.IntegrationTests
{
    using NUnit.Framework;

    [TestFixture]
    public class when_managing_applications
    {
        protected VcapClient CloudActive;
        private const string TestApplicationName = "integration-test";

        [TestFixtureSetUp]
        public void with_known_good_cloud_target()
        {
            CloudActive = new VcapClient(TestAccountInformation.GoodUri.ToString());
            CloudActive.Login(
                TestAccountInformation.Username,
                TestAccountInformation.Password);
        }

        [TestFixtureTearDown]
        public void cleaning_up_the_testing()
        {
            var testApplication = CloudActive.GetApplication(TestApplicationName);
            if(testApplication != null && testApplication.IsStarted || testApplication.IsStopped)
                CloudActive.Delete(testApplication);
        }

        [Test]
        public void should_detect_known_apps()
        {
            var apps = CloudActive.GetApplications();
            apps.Should().NotBeNull();
        }

        [Test]
        public void vmcshould_deploy_an_application()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var pathToTestApp = new DirectoryInfo(currentDirectory + @"\TestAppToPush");
          
            CloudActive.Push(TestApplicationName, "http://integration-test.api.ironfoundry.me", 1,
                pathToTestApp, 64, null);

            var testApplication = CloudActive.GetApplication(TestApplicationName);

            testApplication.IsStarted.Should().BeTrue();

            CloudActive.Delete(TestApplicationName);
        }
    }
}
