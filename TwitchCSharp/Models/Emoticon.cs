using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("emoticons")]
    public class Emoticon
    {
        [JsonProperty("regex")]
        public string Regex { get; set; }
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }
}