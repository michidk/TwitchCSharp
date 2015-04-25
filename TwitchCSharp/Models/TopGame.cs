using System;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("top")]
    public class TopGame : LinkList
    {
        [JsonProperty("viewers")]
        public long Viewers { get; set; }
        [JsonProperty("channels")]
        public long Channels { get; set; }
        [JsonProperty("game")]
        public Game Game { get; set; }
    }
}