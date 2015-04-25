using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class LinkList
    {
        [JsonProperty("_links")]
        public Dictionary<string, object> Links { get; set; } 
    }
}