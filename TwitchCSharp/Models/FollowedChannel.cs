using System;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    [JsonObject("follows")]
    public class FollowedChannel : TwitchObject
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("notifications")]
        public bool Notifications { get; set; }
        [JsonProperty("channel")]
        public Channel Channel { get; set; } 
    }
}