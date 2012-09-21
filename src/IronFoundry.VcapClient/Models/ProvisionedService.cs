// -----------------------------------------------------------------------
// <copyright file="ProvisionedService.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace IronFoundry.Models
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    public class ProvisionedService : EntityBase
    {        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        [JsonProperty(PropertyName = "tier")]
        public string Tier { get; private set; }

        [JsonProperty(PropertyName = "vendor")]
        public string Vendor { get; private set; }

        [JsonProperty(PropertyName = "meta")]
        public Meta MetaData { get; private set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; private set; }
    }

    [Serializable]
    public class Meta : EntityBase
    {
        [JsonProperty(PropertyName = "created")]
        public uint Created { get; set; }

        [JsonProperty(PropertyName = "updated")]
        public uint Updated { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string[] Tags { get; set; }
        
        [JsonProperty(PropertyName = "version")]
        public uint Version { get; set; }
    }
}
