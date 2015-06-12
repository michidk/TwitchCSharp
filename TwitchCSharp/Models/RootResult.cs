using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class RootResult
    {
        [JsonProperty("token")]
        public Token Token { get; set; }
    }
}