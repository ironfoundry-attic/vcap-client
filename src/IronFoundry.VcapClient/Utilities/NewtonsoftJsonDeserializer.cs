// -----------------------------------------------------------------------
// <copyright file="NewtonsoftJsonDeserializer.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace IronFoundry.Utilities
{
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Deserializers;

    public class NewtonsoftJsonDeserializer : IDeserializer
    {
        public const string JsonContentType = "application/json"; 

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string ContentType
        {
            get { return JsonContentType; }
        }
    }
}
