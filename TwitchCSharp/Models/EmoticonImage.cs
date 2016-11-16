using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("emoticons")]
    public class EmoticonImage
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("emoticon_set")]
        public long EmoticonSet { get; set; }
    }
}