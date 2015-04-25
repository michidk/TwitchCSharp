using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class Image
    {
        [JsonProperty("emoticon_set")]
        public long EmoticonSet { get; set; }
        [JsonProperty("height")]
        public long Height { get; set; }
        [JsonProperty("width")]
        public long Width { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}