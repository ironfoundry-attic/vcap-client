// -----------------------------------------------------------------------
// <copyright file="SystemService.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace IronFoundry.Models
{
    [Serializable]
    public class SystemService : EntityBase
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "vendor")]
        public string Vendor { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}