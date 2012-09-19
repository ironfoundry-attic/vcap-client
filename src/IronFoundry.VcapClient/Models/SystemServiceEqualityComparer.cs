// -----------------------------------------------------------------------
// <copyright file="SystemServiceEqualityComparer.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace IronFoundry.Models
{
    using System.Collections.Generic;

    public class SystemServiceEqualityComparer : IEqualityComparer<SystemService>
    {
        public bool Equals(SystemService c1, SystemService c2)
        {
            return c1.Vendor.Equals(c2.Vendor);
        }

        public int GetHashCode(SystemService c)
        {
            return c.Vendor.GetHashCode();
        }
    }
}
