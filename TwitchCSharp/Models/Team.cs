using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("teams")]
    public class Team : TwitchObject
    {
        [JsonProperty("_id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("info")]
        public string Info { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("logo")]
        public string Logo { get; set; }
        [JsonProperty("banner")]
        public string Banner { get; set; }
        [JsonProperty("background")]
        public string Background { get; set; }
    }
}