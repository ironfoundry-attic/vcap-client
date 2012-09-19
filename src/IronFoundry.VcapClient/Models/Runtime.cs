namespace IronFoundry.Models
{
    using Newtonsoft.Json;

    public class Runtime : EntityBase
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; private set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    }
}