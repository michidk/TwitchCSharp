using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class ViewerList
    {
        [JsonProperty("_links")]
        public Dictionary<string, string> Links;
        [JsonProperty("chatter_count")]
        public int ChatterCount;
        [JsonProperty("chatters")]
        public Chatter Chatters;
    }
}
