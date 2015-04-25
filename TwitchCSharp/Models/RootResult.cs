using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class RootResult : LinkList
    {
        [JsonProperty("token")]
        public Token Token { get; set; }
    }
}