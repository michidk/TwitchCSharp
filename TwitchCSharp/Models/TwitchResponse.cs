using System;
using Newtonsoft.Json;
using TwitchCSharp.Enums;

namespace TwitchCSharp.Models
{
    public class TwitchResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("_total")]
        public long Total { get; set; }

        public TwitchResponse() {}

        public State GetState()
        {
            State state;
            switch (Status)
            {
                case 204:
                    state = State.success;
                    break;
                case 404:
                    state = State.not_found;
                    break;
                case 422:
                    state = State.failed;
                    break;
                case 503:
                    state = State.failed;
                    break;
                default:
                    state = State.failed;
                    break;
            }
            return state;
        }

        [Obsolete("Method obsolete, please use GetState() instead")]
        public bool WasSuccesfull()
        {
            return Status == 204;
        }
    }
}