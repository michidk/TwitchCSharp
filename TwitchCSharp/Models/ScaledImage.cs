using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class ScaledImage
    {
        [JsonProperty("large")]
        public string Large { get; set; }
        [JsonProperty("medium")]
        public string Medium { get; set; }
        [JsonProperty("small")]
        public string Small { get; set; }
        [JsonProperty("template")]
        public string Template { get; set; } 
    }
}