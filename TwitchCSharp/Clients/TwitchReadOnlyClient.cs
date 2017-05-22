using RestSharp;
using TwitchCSharp.Enums;
using TwitchCSharp.Helpers;
using TwitchCSharp.Models;

namespace TwitchCSharp.Clients
{
    public class TwitchReadOnlyClient : ITwitchClient
    {

        public readonly RestClient restClient;

        public TwitchReadOnlyClient(string clientID, string url = TwitchHelper.twitchApiUrl)
        {
            restClient = new RestClient(url);
            restClient.AddHandler("application/json", new DynamicJsonDeserializer());
            restClient.AddHandler("text/html", new DynamicJsonDeserializer());
            restClient.AddDefaultHeader("Accept", TwitchHelper.twitchAcceptHeader);
            restClient.AddDefaultHeader("Client-ID", clientID);
        }

        public Channel GetChannel(string channel)
        {
            var request = GetRequest("channels/{channel}", Method.GET);
            request.AddUrlSegment("channel", channel);
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        public TwitchList<Team> GetTeams(string channel)
        {
            var request = GetRequest("channels/{channel}/teams", Method.GET);
            request.AddUrlSegment("channel", channel);
            var response = restClient.Execute<TwitchList<Team>>(request);
            return response.Data;
        }

        public TwitchList<Emoticon> GetEmoticons()
        {
            var request = GetRequest("chat/emoticons", Method.GET);
            var data = restClient.DownloadData(request);
            var value = System.Text.Encoding.Default.GetString(data);
            return DynamicJsonDeserializer.Deserialize<TwitchList<Emoticon>>(value);
        }

        public TwitchList<EmoticonImage> GetEmoticonImages()
        {
            var request = GetRequest("chat/emoticon_images", Method.GET);
            var response = restClient.Execute<TwitchList<EmoticonImage>>(request);
            return response.Data;
        }

        public BadgeResult GetBadges(string channel)
        {
            var request = GetRequest("chat/{channel}/badges", Method.GET);
            request.AddUrlSegment("channel", channel);
            var response = restClient.Execute<BadgeResult>(request);
            return response.Data;
        }

        public TwitchList<Follower> GetFollowers(string channel, PagingInfo pagingInfo = null)
        {
            var request = GetRequest("channels/{channel}/follows", Method.GET);
            request.AddUrlSegment("channel", channel);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Follower>>(request);
            return response.Data;
        }

        public TwitchList<FollowedChannel> GetFollowedChannels(string user, PagingInfo pagingInfo = null, SortDirection sortDirection = SortDirection.desc, SortType sortType = SortType.created_at)
        {
            var request = GetRequest("users/{user}/follows/channels", Method.GET);
            request.AddUrlSegment("user", user);
            TwitchHelper.AddPaging(request, pagingInfo);
            request.AddParameter("direction", sortDirection);
            request.AddParameter("sortby", sortType);
            var response = restClient.Execute<TwitchList<FollowedChannel>>(request);
            return response.Data;
        }

        public FollowedChannel GetFollowedChannel(string user, string target)
        {
            var request = GetRequest("users/{user}/follows/channels/{target}", Method.GET);
            request.AddUrlSegment("user", user);
            request.AddUrlSegment("target", target);
            var response = restClient.Execute<FollowedChannel>(request);
            return response.Data;
        }

        public bool IsFollowing(string user, string target)
        {
            return GetFollowedChannel(user, target).Status != 404;
        }

        public TwitchList<TopGame> GetTopGames(PagingInfo pagingInfo = null)
        {
            var request = GetRequest("games/top", Method.GET);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<TopGame>>(request);
            return response.Data;
        }

        public TwitchList<Ingest> GetIngests()
        {
            var request = GetRequest("ingests/", Method.GET);
            var response = restClient.Execute<TwitchList<Ingest>>(request);
            return response.Data;
        }

        public RootResult GetRoot()
        {
            var request = GetRequest("/", Method.GET);
            var response = restClient.Execute<RootResult>(request);
            return response.Data;
        }

        public TwitchList<Channel> SearchChannels(string query, PagingInfo pagingInfo = null)
        {
            var request = GetRequest("search/channels", Method.GET);
            request.AddParameter("query", query);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Channel>>(request);
            return response.Data;
        }

        public TwitchList<Stream> SearchStreams(string query, PagingInfo pagingInfo = null)
        {
            var request = GetRequest("search/streams", Method.GET);
            request.AddParameter("query", query);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Stream>>(request);
            return response.Data;
        }

        public TwitchList<Stream> SearchStreams(string query, bool hls, PagingInfo pagingInfo = null)
        {
            var request = GetRequest("search/streams", Method.GET);
            request.AddParameter("query", query);
            request.AddParameter("hls", hls);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Stream>>(request);
            return response.Data;
        }

        public TwitchList<Game> SearchGames(string query, bool live = false, PagingInfo pagingInfo = null)
        {
            var request = GetRequest("search/games", Method.GET);
            request.AddParameter("query", query);
            request.AddParameter("type", "suggest");                // currently no other types than "suggest"
            request.AddParameter("live", live);                     // if live = true, only returns games that are live on at least one channel.
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Game>>(request);
            return response.Data;
        }

        //stream = null if channel is offline
        public StreamResult GetStream(string channel)
        {
            var request = GetRequest("streams/{channel}", Method.GET);
            request.AddUrlSegment("channel", channel);
            var response = restClient.Execute<StreamResult>(request);
            return response.Data;
        }

        public bool IsLive(string channel)
        {
            return GetStream(channel).Stream != null;
        }

        public TwitchList<Stream> GetStreams(string game = null, string channel = null, string clientId = null, PagingInfo pagingInfo = null)
        {
            var request = GetRequest("streams", Method.GET);
            request.AddSafeParameter("game", game);
            request.AddSafeParameter("channel", channel);
            TwitchHelper.AddPaging(request, pagingInfo);
            request.AddSafeParameter("client_id", clientId);
            var response = restClient.Execute<TwitchList<Stream>>(request);
            return response.Data;
        }

        public TwitchList<Featured> GetFeaturedStreams(PagingInfo pagingInfo = null)
        {
            var request = GetRequest("streams/featured", Method.GET);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Featured>>(request);
            return response.Data;
        }

        public StreamSummary GetStreamSummary(string game = null)
        {
            var request = GetRequest("streams/summary", Method.GET);
            request.AddSafeParameter("game", game);
            var response = restClient.Execute<StreamSummary>(request);
            return response.Data;
        }

        public TwitchList<Team> GetTeams(PagingInfo pagingInfo = null)
        {
            var request = GetRequest("teams", Method.GET);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Team>>(request);
            return response.Data;
        }

        public Team GetTeam(string team)
        {
            var request = GetRequest("teams/{team}", Method.GET);
            request.AddUrlSegment("team", team);
            var response = restClient.Execute<Team>(request);
            return response.Data;
        }

        public User GetUser(string user)
        {
            var request = GetRequest("users/{user}", Method.GET);
            request.AddUrlSegment("user", user);
            var response = restClient.Execute<User>(request);
            return response.Data;
        }

        public Video GetVideo(string id)
        {
            var request = GetRequest("videos/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = restClient.Execute<Video>(request);
            return response.Data;
        }

        public TwitchList<Video> GetTopVideos(string game = null, PeriodType period = PeriodType.week, PagingInfo pagingInfo = null)
        {
            var request = GetRequest("videos/top", Method.GET);
            request.AddSafeParameter("game", game);
            request.AddParameter("period", period);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Video>>(request);
            return response.Data;
        }

        public TwitchList<Video> GetChannelVideos(string channel, bool broadcasts = false, bool hls = false, PagingInfo pagingInfo = null)
        {
            var request = GetRequest("channels/{channel}/videos", Method.GET);
            request.AddUrlSegment("channel", channel);
            request.AddParameter("broadcasts", broadcasts);
            request.AddParameter("hls", hls);
            TwitchHelper.AddPaging(request, pagingInfo);
            var response = restClient.Execute<TwitchList<Video>>(request);
            return response.Data;
        }


        public RestRequest GetRequest(string url, Method method)
        {
            return new RestRequest(url, method);
        }
    }
}