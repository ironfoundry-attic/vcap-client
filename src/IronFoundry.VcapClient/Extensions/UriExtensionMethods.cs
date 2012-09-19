namespace IronFoundry.Extensions
{
    using System;

    public static class UriExtensionMethods
    {
        private static readonly char[] TrimChars = new char[] { '/' };

        public static string AbsoluteUriTrimmed(this Uri argThis)
        {
            return argThis.AbsoluteUri.TrimEnd(TrimChars);
        }
    }
}