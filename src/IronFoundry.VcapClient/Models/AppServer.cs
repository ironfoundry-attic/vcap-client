// -----------------------------------------------------------------------
// <copyright file="AppServer.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace IronFoundry.Models
{
    public class AppServer : EntityBase
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    }
}