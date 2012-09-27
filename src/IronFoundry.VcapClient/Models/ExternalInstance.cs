// -----------------------------------------------------------------------
// <copyright file="ExternalInstance.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace IronFoundry.Models
{
    public class ExternalInstance : EntityBase
    {
        [JsonProperty(PropertyName = "instances")]
        public InstanceDetail[] ExternInstance { get; set; }
    }

    public class InstanceDetail : EntityBase
    {
        [JsonProperty(PropertyName = "index")]
        public int Index { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "since")]
        public int Since { get; set; }

        [JsonProperty(PropertyName = "debug_port")]
        public string DebugPort { get; set; }
    }
}