using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("featured")]
    public class Featured
    {
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("sponsored")]
        public bool Sponsored { get; set; }
        [JsonProperty("scheduled")]
        public bool Scheduled { get; set; }
        [JsonProperty("stream")]
        public Stream Stream { get; set; }
    }
}