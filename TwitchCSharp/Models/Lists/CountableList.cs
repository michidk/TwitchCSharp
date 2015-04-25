using Newtonsoft.Json;

namespace TwitchCSharp.Models.Lists
{
    public class CountableList : TwitchObject
    {
        [JsonProperty("_total")]
        public long Total { get; set; } 
    }
}