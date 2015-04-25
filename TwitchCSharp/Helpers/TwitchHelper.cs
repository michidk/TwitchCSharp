using RestSharp;

namespace TwitchCSharp.Helpers
{
    public class TwitchHelper
    {
        public const string twitchApiUrl = "https://api.twitch.tv/kraken";
        public const string twitchAcceptHeader = "application/vnd.twitchtv.v3+json";

        public static void AddPaging(IRestRequest request, PagingInfo pagingInfo)
        {
            if (pagingInfo == null) return;
            request.AddParameter("limit", pagingInfo.PageSize);
            request.AddParameter("offset", pagingInfo.Page - 1);
        }
    }
}