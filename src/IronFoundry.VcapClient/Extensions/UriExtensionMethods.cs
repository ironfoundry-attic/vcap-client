// -----------------------------------------------------------------------
// <copyright file="UriExtensionMethods.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

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
