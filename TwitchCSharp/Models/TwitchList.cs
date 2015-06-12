using System.Collections.Generic;
using Newtonsoft.Json;
using TwitchCSharp.Helpers;

namespace TwitchCSharp.Models
{
    //@author gibletto

    [JsonObject(ItemConverterType = typeof (TwitchListConverter))]
    public class TwitchList<T> : TwitchResponse
    {
        public List<T> List { get; set; }
    }
}