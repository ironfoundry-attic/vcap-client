using System;

namespace IronFoundry.VcapClient.IntegrationTests
{
    public static class AppFogTestAccountInformation
    {
        // This is a real test account specifically for this integration testing lib.
        public static string username = "te????l@tier3.com";
        public static string password = "???test123!";
        public static Uri goodUri = new Uri("http://api.eu01.aws.af.com");
        public static Uri fqdnUri = new Uri("http://integration-tests.eu01.aws.af.com");
    }
}