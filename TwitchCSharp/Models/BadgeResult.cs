using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class BadgeResult
    {
        [JsonProperty("global_mod")]
        public Badge GlobalMod { get; set; }
        [JsonProperty("admin")]
        public Badge Admin { get; set; }
        [JsonProperty("broadcaster")]
        public Badge Broadcaster { get; set; }
        [JsonProperty("mod")]
        public Badge Mod { get; set; }
        [JsonProperty("staff")]
        public Badge Staff { get; set; }
        [JsonProperty("turbo")]
        public Badge Turbo { get; set; }
        [JsonProperty("subscriber")]
        public Badge Subscriber { get; set; }
    }
}