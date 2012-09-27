// -----------------------------------------------------------------------
// <copyright file="StatInfo.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace IronFoundry.Models
{
    public class StatInfo : EntityBase
    {
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "stats")]
        public Stats Stats { get; set; }

        [JsonIgnore]
        public int ID { get; set; }
    }
}