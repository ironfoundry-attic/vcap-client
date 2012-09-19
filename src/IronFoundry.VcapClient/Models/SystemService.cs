namespace IronFoundry.Models
{
    using System;
    using Newtonsoft.Json;

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