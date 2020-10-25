using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LABO5.Models
{
    public class TrelloBoard
    {
        [JsonProperty(PropertyName = "id")]        
        public string BoardId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "starred")]
        public bool IsFavorite { get; set; }

    }
}
