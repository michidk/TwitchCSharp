using RestSharp;
using TwitchCSharp.Enums;
using TwitchCSharp.Helpers;
using TwitchCSharp.Models;
using TwitchCSharp.Models.Lists;

namespace TwitchCSharp.Clients
{
    public class TwitchAuthenticatedClient : TwitchReadOnlyClient, ITwitchClient
    {

        private readonly string oauth;
        private readonly string clientId;

        public TwitchAuthenticatedClient(string oauth, string clientId) : base()
        {
            this.oauth = oauth;
            this.clientId = clientId;
        }

        public Channel GetMyChannel()
        {
            var request = GetRequest("channel", Method.GET);
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        // more details that GetUser(myname)
        public User GetMyUser()
        {
            var request = GetRequest("user", Method.GET);
            var response = restClient.Execute<User>(request);
            return response.Data;
        }

        public TwitchList<Stream> GetFollowedStreams(PagingInfo pagingInfo = null)
        {
            var request = GetRequest("streams/followed", Method.GET);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Stream>>(request);
            return response.Data;
        }

        public TwitchList<Video> GetFollowedVideos(PagingInfo pagingInfo = null)
        {
            var request = GetRequest("videos/followed", Method.GET);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Video>>(request);
            return response.Data;
        }


        public RestRequest GetRequest(string url, Method method)
        {
            RestRequest restRequest = new RestRequest(url, method);
            restRequest.AddHeader("Client-ID", clientId);
            restRequest.AddHeader("Authorization", string.Format("OAuth {0}", oauth));
            return restRequest;
        }
    }
}