namespace IronFoundry.Models
{
    using Newtonsoft.Json;

    public class AppServer : EntityBase
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    }
}