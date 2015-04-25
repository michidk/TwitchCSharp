using System.Collections.Generic;
using Newtonsoft.Json;
using TwitchCSharp.Helpers;

namespace TwitchCSharp.Models.Lists
{
    //@author gibletto

    [JsonObject(ItemConverterType = typeof (TwitchListConverter))]
    public class TwitchList<T> : CountableList
    {
        public List<T> List { get; set; }
    }
}