using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("blocks")]
    public class Block : TwitchObject
    {
        [JsonProperty("_id")]
        public long Id { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
    }
}