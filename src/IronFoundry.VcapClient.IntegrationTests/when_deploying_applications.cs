
using System.IO;
using FluentAssertions;

namespace IronFoundry.VcapClient.IntegrationTests
{
    using NUnit.Framework;

    [TestFixture]
    public class when_deploying_applications
    {
        protected VcapClient cloudActive;

        [TestFixtureSetUp]
        public void with_known_good_cloud_target()
        {
            cloudActive = new VcapClient(TestAccountInformation.GoodUri.ToString());
            cloudActive.Login(
                TestAccountInformation.Username,
                TestAccountInformation.Password);
        }

        [TestFixtureTearDown]
        public void cleaning_up_the_testing()
        {
            var apps = cloudActive.GetApplications();
          
            foreach (var application in apps)
            {
                cloudActive.Delete(application.Name);
            }
        }

        [Test]
        public void should_detect_known_apps()
        {
            var apps = cloudActive.GetApplications();
            apps.Should().NotBeNull();
        }

        [Test]
        public void should_deploy_a_sample_nodejs_application()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var pathToTestApp = new DirectoryInfo(currentDirectory + TestAccountInformation.TestAppToPush);

            cloudActive.Push(TestAccountInformation.TestApplicationName, TestAccountInformation.HttpIntegrationTestApiIronfoundryMe, 1,
                pathToTestApp, 64, null);
            var testApplication = cloudActive.GetApplication(TestAccountInformation.TestApplicationName);
            testApplication.IsStarted.Should().BeTrue();

            cloudActive.Delete(TestAccountInformation.TestApplicationName);
        }

        [Test]
        public void should_delete_an_application()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var pathToTestApp = new DirectoryInfo(currentDirectory + TestAccountInformation.TestAppToPush);

            cloudActive.Push(TestAccountInformation.TestApplicationName, TestAccountInformation.HttpIntegrationTestApiIronfoundryMe, 1,
                pathToTestApp, 64, null);
            var testApplication = cloudActive.GetApplication(TestAccountInformation.TestApplicationName);
            testApplication.IsStarted.Should().BeTrue();

            cloudActive.Delete(TestAccountInformation.TestApplicationName);

            var apps = cloudActive.GetApplications();
            var exists = false;

            foreach (var application in apps)
            {
                if (application.Name == TestAccountInformation.TestApplicationName)
                    exists = true;
            }

            exists.Should().BeFalse();
        }
    }
}
