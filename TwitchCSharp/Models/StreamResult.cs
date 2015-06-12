using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class StreamResult : TwitchResponse
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }
    }
}