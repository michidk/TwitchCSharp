using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("badges")]
    public class Badge
    {
        [JsonProperty("alpha")]
        public string Alpha { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("svg")]
        public string Svg { get; set; }
    }
}