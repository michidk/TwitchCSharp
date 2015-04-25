using System;
using RestSharp;
using RestSharp.Deserializers;

namespace TwitchCSharp
{
    public class TwitchConnection
    {
        public readonly string username;
        public readonly string clientId;
        public readonly string oAuthToken;

        public TwitchConnection(string username, string clientId, string oAuthToken)
        {
            this.username = username;
            this.clientId = clientId;
            this.oAuthToken = oAuthToken;
        }
    }
}