namespace IronFoundry.VcapClient
{
    using System;

    public class Constants
    {
        private static readonly Uri DefaultTargetFld       = new Uri("http://api.cloudfoundry.com");
        private static readonly Uri DefaultLocalTargetFld = new Uri("http://api.vcap.me");

        public const string InfoResource           = "/info";
        public const string GlobalServicesResource = "/info/services";
        public const string ResourcesResource      = "/resources";

        public const string AppsResource     = "/apps";
        public const string ServicesResource = "/services";
        public const string UsersResource    = "/users";

        public static Uri DefaultTarget { get { return DefaultTargetFld; } }
        public static Uri DefaultLocalTarget { get { return DefaultLocalTargetFld; } }
    }
}
