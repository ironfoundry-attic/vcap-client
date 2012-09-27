// -----------------------------------------------------------------------
// <copyright file="VcapUserApp.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace IronFoundry.Models
{
    public class VcapUserApp
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}