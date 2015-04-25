using RestSharp;

namespace TwitchCSharp.Clients
{
    public interface ITwitchClient
    {
        RestRequest GetRequest(string url, Method method);
    }
}