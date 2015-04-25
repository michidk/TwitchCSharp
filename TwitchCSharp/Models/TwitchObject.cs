using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TwitchCSharp.Models
{
    public abstract class TwitchObject : LinkList
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}