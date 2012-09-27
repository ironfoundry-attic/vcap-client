// -----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace IronFoundry.Utilities
{
    public static class Constants
    {
        private static readonly int[] MemoryLimitsField = new int[6] {64, 128, 256, 512, 1024, 2048};

        public static int[] MemoryLimits
        {
            get { return MemoryLimitsField; }
        }
    }
}