using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LABO5.Models
{
    public class TrelloList
    {
        [JsonProperty(PropertyName ="id")]
        public string ListId { get; set; }// name of property we want to use
        [JsonProperty(propertyName:"name")]
        public string Name { get; set; }
       
  
    }
}
