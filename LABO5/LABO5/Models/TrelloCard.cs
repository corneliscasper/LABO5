using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LABO5.Models
{
    public class TrelloCard
    {

        [JsonProperty(PropertyName = "id")]
        public string CardId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "closed")]
        public bool IsClosed { get; set; }

    }
}
