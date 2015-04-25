using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class StreamResult : TwitchObject
    {
        [JsonProperty("stream")]
        public Stream Stream { get; set; }
    }
}