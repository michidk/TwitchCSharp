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

        public StreamResult GetMyStream()
        {
            return GetStream(username);
        }

        public TwitchList<Block> GetBlocks()
        {
            var request = GetRequest("users/{user}/blocks", Method.GET);
            request.AddUrlSegment("user", username);
            var response = restClient.Execute<TwitchList<Block>>(request);
            return response.Data;
        }

        public Response Block(string target)
        {
            var request = GetRequest("users/{user}/blocks/{target}", Method.PUT);
            request.AddUrlSegment("user", username);
            request.AddUrlSegment("target", target);
            var response = restClient.Execute<Response>(request);
            return response.Data;
        }

        public Response Unblock(string target)
        {
            var request = GetRequest("users/{user}/blocks/{target}", Method.DELETE);
            request.AddUrlSegment("user", username);
            request.AddUrlSegment("target", target);
            var response = restClient.Execute<Response>(request);
            return response.Data;
        }

        public TwitchList<User> GetChannelEditors()
        {
            var request = GetRequest("channels/{channel}/editors", Method.GET);
            request.AddUrlSegment("channel", username);
            var response = restClient.Execute<TwitchList<User>>(request);
            return response.Data;
        }

        public Channel Update(string status = null, string game = null, string delay = null)
        {
            var request = GetRequest("channels/{channel}", Method.PUT);
            request.AddUrlSegment("channel", username);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { channel = new { status, game, delay } });
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        public Channel SetTitle(string title)
        {
            return Update(title);
        }

        public Channel SetGame(string game)
        {
            return Update(null, game);
        }

        // only for partnered channels
        public Channel SetDelay(string delay)
        {
            return Update(null, null, delay);
        }

        public User ResetStreamKey()
        {
            var request = GetRequest("channels/{channel}/stream_key", Method.DELETE);
            request.AddUrlSegment("channel", username);
            var response = restClient.Execute<User>(request);
            return response.Data;
        }

        // Length of commercial break in seconds. Default value is 30. Valid values are 30, 60, 90, 120, 150, and 180. You can only trigger a commercial once every 8 minutes.
        public Response TriggerCommercial(int length)
        {
            var request = GetRequest("channels/{channel}/commercial", Method.POST);
            request.AddUrlSegment("channel", username);
            request.AddParameter("length", length);
            var response = restClient.Execute<Response>(request);
            return response.Data;
        }

        public FollowedChannel Follow(string target, bool notifications = false)
        {
            var request = GetRequest("users/{user}/follows/channels/{target}", Method.PUT);
            request.AddUrlSegment("user", username);
            request.AddUrlSegment("target", target);
            request.AddParameter("notifications", notifications);
            var response = restClient.Execute<FollowedChannel>(request);
            return response.Data;
        }

        public Response Unfollow(string target)
        {
            var request = GetRequest("users/{user}/follows/channels/{target}", Method.DELETE);
            request.AddUrlSegment("user", username);
            request.AddUrlSegment("target", target);
            var response = restClient.Execute<Response>(request);
            return response.Data;
        }

        public TwitchList<Subscription> GetSubscribers(PagingInfo pagingInfo = null, SortDirection sortDirection = SortDirection.asc)
        {
            var request = GetRequest("channels/{channel}/subscriptions", Method.GET);
            request.AddUrlSegment("channel", username);
            TwitchHelper.AddPaging(request, pagingInfo);
            request.AddParameter("direction", sortDirection);
            var response = restClient.Execute<TwitchList<Subscription>>(request);
            return response.Data;
        }

        // someone who subscribed your channel
        public Subscription GetSubscriber(string user)
        {
            var request = GetRequest("channels/{channel}/subscriptions/{user}", Method.GET);
            request.AddUrlSegment("channel", username);
            request.AddUrlSegment("user", user);
            var response = restClient.Execute<Subscription>(request);
            return response.Data;
        }

        public bool IsSubscriber(string user)
        {
            return GetSubscriber(user).Status != 404;
        }

        // a channel you subscribed
        public Subscription GetSubscribedChannel(string channel)
        {
            var request = GetRequest("users/{user}/subscriptions/{channel}", Method.GET);
            request.AddUrlSegment("user", username);
            request.AddUrlSegment("channel", channel);
            var response = restClient.Execute<Subscription>(request);
            return response.Data;
        }

        public bool IsSubscribedToChannel(string channel)
        {
            return GetSubscribedChannel(channel).Status != 404;
        }

        // has the channel a subscription programm?
        public bool CanSubscribeToChannel(string channel)
        {
            return GetSubscribedChannel(channel).Status != 422;
        }
    }
}