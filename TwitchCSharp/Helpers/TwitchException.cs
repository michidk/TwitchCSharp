using System;

namespace TwitchCSharp.Helpers
{
    public class TwitchException : Exception
    {
        public TwitchException() { }

        public TwitchException(string message) : this(message, null) { }

        public TwitchException(string message, Exception inner) : base(message, inner) { }
    }
}