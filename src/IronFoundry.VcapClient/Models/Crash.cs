// -----------------------------------------------------------------------
// <copyright file="Crash.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace IronFoundry.Models
{
    public class Crash : EntityBase
    {
        [JsonProperty(PropertyName = "instance")]
        public string Instance { get; private set; }

        [JsonProperty(PropertyName = "since")]
        public int Since { get; private set; }
    }
}