namespace IronFoundry.VcapClient.IntegrationTests
{
    using System;
    
    public static class TestAccountInformation
    {
        // This is a real test account specifically for this integration testing lib.
        public const string Username = "test-email@tier3.com";
        public const string Password = "test123!";
        public static readonly Uri GoodUri = new Uri("http://api.ironfoundry.me");
        public static readonly Uri FqdnUri = new Uri("http://integrationtests.ironfoundry.me");
        public const string TestAppToPush = @"\TestAppToPush";
        public const string HttpIntegrationTestApiIronfoundryMe = "http://integration-test.api.ironfoundry.me";
        public const string TestApplicationName = "integration-test";
    }
}
