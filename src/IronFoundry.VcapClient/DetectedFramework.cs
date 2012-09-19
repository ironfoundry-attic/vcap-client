// -----------------------------------------------------------------------
// <copyright file="DetectedFramework.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace IronFoundry.VcapClient
{
    public class DetetectedFramework
    {
        public string Framework { get; set; }
        public string Runtime { get; set; }
        public uint DefaultMemoryMB { get; set; }
    }
}