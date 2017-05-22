using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwitchCSharp.Models
{
    public class Chatters
    {
        [JsonProperty("moderators")] public string[] Moderators;
        [JsonProperty("staff")] public string[] Staff;
        [JsonProperty("admins")] public string[] Admins;
        [JsonProperty("global_mods")] public string[] GlobalMods;
        [JsonProperty("viewers")] public string[] Viewers;
    }
}
