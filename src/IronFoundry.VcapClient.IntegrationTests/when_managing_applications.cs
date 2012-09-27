using System.IO;
using FluentAssertions;
using IronFoundry.Models;
using NUnit.Framework;

namespace IronFoundry.VcapClient.IntegrationTests
{
    [TestFixture]
   public class when_managing_applications
    {
        protected VcapClient cloudActive;
        protected Application testApplication;

        [TestFixtureSetUp]
        public void with_a_standard_default_application()
        {
            cloudActive = new VcapClient(TestAccountInformation.GoodUri.ToString());
            cloudActive.Login(
                TestAccountInformation.Username,
                TestAccountInformation.Password);

            var currentDirectory = Directory.GetCurrentDirectory();
            var pathToTestApp = new DirectoryInfo(currentDirectory + TestAccountInformation.TestAppToPush);

            cloudActive.Push(TestAccountInformation.TestApplicationName, TestAccountInformation.HttpIntegrationTestApiIronfoundryMe, 1,
                pathToTestApp, 64, null);
            testApplication = cloudActive.GetApplication(TestAccountInformation.TestApplicationName);
         
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
        public void should_have_one_instance_running()
        {
            testApplication.InstanceCount.Should().Be(1);
        }

        [Test]
        public void should_stop_an_application_from_running()
        {
            testApplication.Stop();
            testApplication.IsStopped.Should().BeTrue();
            testApplication.IsStarted.Should().BeFalse();
        }

        [Test]
        public void should_start_an_application_if_stopped()
        {
            testApplication.Stop();
            testApplication.Start();
            testApplication.IsStarted.Should().BeTrue();
            testApplication.IsStopped.Should().BeFalse();
        }
    }
}
