using System;
using RestSharp;
using TwitchCSharp.Enums;
using TwitchCSharp.Helpers;
using TwitchCSharp.Models;
using TwitchCSharp.Models.Lists;

namespace TwitchCSharp.Clients
{
    [Obsolete("This class is deprecated, please use TwitchAuthenticatedClient instead.")]
    public class TwitchNamedClient : TwitchAuthenticatedClient, ITwitchClient
    {

        private readonly string username;

        public TwitchNamedClient(string username, string oauth, string clientId) : base(oauth, clientId)
        {
            this.username = username;
        }

    }
}