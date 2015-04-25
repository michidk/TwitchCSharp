namespace TwitchCSharp.Models
{
    public class Response : TwitchObject
    {
        public Response()
        {
        }

        public bool WasSuccesfull()
        {
            return Status == 204;
        }
    }
}