using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class Channel : TwitchObject
    {
        [JsonProperty("_id")]
        public long Id { get; set; }
        [JsonProperty("mature")]
        public bool Mature { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("broadcaster_language")]
        public string BroadcasterLanguage { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("game")]
        public string Game { get; set; }
        [JsonProperty("delay")]
        public long Delay { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("logo")]
        public string Logo { get; set; }
        [JsonProperty("banner")]
        public string Banner { get; set; }
        [JsonProperty("video_banner")]
        public string VideoBanner { get; set; }
        [JsonProperty("background")]
        public object Background { get; set; }
        [JsonProperty("profile_banner")]
        public string ProfileBanner { get; set; }
        [JsonProperty("profile_banner_background_color")]
        public string ProfileBannerBackgroundColor { get; set; }
        [JsonProperty("partner")]
        public bool Partner { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("views")]
        public long Views { get; set; }
        [JsonProperty("followers")]
        public long Followers { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("stream_key")]
        public string StreamKey { get; set; }
    }
}