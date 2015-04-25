using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class Ingest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("default")]
        public bool Default { get; set; }
        [JsonProperty("_id")]
        public long Id { get; set; }
        [JsonProperty("url_template")]
        public string UrlTemplate { get; set; }
        [JsonProperty("availability")]
        public double Availability { get; set; }
    }
}