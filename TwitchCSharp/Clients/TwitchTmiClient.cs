using RestSharp;
using TwitchCSharp.Helpers;
using TwitchCSharp.Models;

namespace TwitchCSharp.Clients
{
    public class TwitchTmiClient : ITwitchClient
    {
        private readonly RestClient _restClient;

        public TwitchTmiClient(string url = TwitchHelper.TwitchTmiUrl)
        {
            _restClient = new RestClient(url);
            _restClient.AddHandler("application/json", new DynamicJsonDeserializer());
            _restClient.AddHandler("text/html", new DynamicJsonDeserializer());
            _restClient.AddDefaultHeader("Accept", TwitchHelper.twitchAcceptHeader);
        }

        public ViewerList GetChannelViewers(string channel)
        {
            var request = new RestRequest("group/user/{channel}/chatters");
            request.AddUrlSegment("channel", channel);
            return _restClient.Execute<ViewerList>(request).Data;
        }

        public RestRequest GetRequest(string url, Method method)
        {
            return new RestRequest(url, method);
        }
    }
}
