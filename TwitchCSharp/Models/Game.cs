using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("games")]
    public class Game
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("box")]
        public ScaledImage Box { get; set; }
        [JsonProperty("logo")]
        public ScaledImage Logo { get; set; }
        [JsonProperty("_id")]
        public long Id { get; set; }
        [JsonProperty("giantbomb_id")]
        public long GiantbombId { get; set; }
        [JsonProperty("popularity")]
        public long Popularity { get; set; }

    }
}