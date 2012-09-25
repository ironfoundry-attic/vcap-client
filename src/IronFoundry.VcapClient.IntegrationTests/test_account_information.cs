namespace IronFoundry.VcapClient.IntegrationTests
{
    using System;
    
    public static class TestAccountInformation
    {
        // This is a real test account specifically for this integration testing lib.
        public static string Username = "test-email@tier3.com";
        public static string Password = "test123!";
        public static Uri GoodUri = new Uri("http://api.ironfoundry.me");
        public static Uri FqdnUri = new Uri("http://integrationtests.ironfoundry.me");
    }
}
