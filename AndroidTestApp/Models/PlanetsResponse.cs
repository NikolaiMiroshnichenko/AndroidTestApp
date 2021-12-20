using Newtonsoft.Json;
using System.Collections.Generic;

namespace AndroidTestApp.Models
{
    public class PlanetsResponse
    {
            [JsonProperty("count")]
            public int Count { get; set; }

            [JsonProperty("next")]
            public string Next { get; set; }

            [JsonProperty("previous")]
            public string Previous { get; set; }

            [JsonProperty("results")]
            public List<Planet> Results { get; set; }
    }
}