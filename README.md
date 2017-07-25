# Twitch C# Wrapper for the Twitch v3 REST API

## Notes
If you are using Twitch C# Wrapper for your project, please let me know! If there are many projects using this API, I will update it more frequently.
If you are interested in a Twitch C# API Wrapper with active support or Unity 5 integration for the new Twitch v5 API and are willing to pay for it, please [contact me](https://lohr-it.de/contact).

For news & updates, follow me on Twitter: [@miichidk](https://twitter.com/miichidk)

## Projects Using Twitch C# Wrapper
- [Simple Twitch Helper](https://github.com/michidk/SimpleTwitchHelper)

## Documentation
This project is just a wrapper, so that you can interact with the Twitch REST API using C#.
That means that most of the methods are named and work like requests of the Twitch REST API.
The Twitch REST API is documented [here](https://dev.twitch.tv/docs/v3).

## Usage
### Client
To interact with the API you need at least a [client-ID](#oauth-key-/-client-id). Some requests can only be made by authorized users. These also need a [OAuth-key](#oauth-key-/-client-id).

There are three client classes:

| Class                          | Explanation                                                            |
| ------------------------------ | ---------------------------------------------------------------------- |
| TwitchReadOnlyClient           | you can use this client without an auth-key to access public data      |
| TwitchAuthenticatedClient      | needs to authenticate via auth-key, can access and change private data |

The TwitchReadOnlyClient can be used to read basic informations which are public on Twitch like the follower count of certain people.
Requests which access data which is not public or do change something (e.g. the stream title) need authentication.
For these requests you should use the TwitchAuthenticatedClient. The authenticated client also has access to all TwitchReadOnlyClient methods.
The TwitchNamedClient is deprecated, since the TwitchAuthenticatedClient automatically fetches the username.

### OAuth-Key / Client-ID
Your client-ID is used to protect the twitch servers from spam-attacks. You can create one [here](http://www.twitch.tv/settings/connections) (scroll to the bottom).

You auth-key is used to authenticate you with the twitch servers. To generate one, just put your client-ID after "client_id=" in the URL and visit the following link:
```
https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=INSERT_YOUR_CLIENT_ID_HERE&redirect_uri=http://localhost&scope=user_read+user_blocks_edit+user_blocks_read+user_follows_edit+channel_read+c
hannel_editor+channel_commercial+channel_stream+channel_subscriptions+user_subscriptions+channel_check_subscription+chat_login
```

You will be redirected to a url like this:
```
http://localhost/#access_token=qxxxxtnc33456quxfghmcpw211s92xgp&scope=user_read+user_blocks_edit+user_blocks_read+user_follows_edit+channel_read+channel_editor+channel_commercial+channel_stream+channel_subscriptions+user_subscriptions+channel_check_subscription+chat_login
```

You can find your auth-key in the resulting url: `#access_token=qxxxxtnc33456quxfghmcpw211s92xgp`
If you create a service, you have to provide a web-frontend, for the users to get their auth-key. Auth-keys are bound to accounts and should not be shared.

Read more about the Twitch authentication API [here](https://dev.twitch.tv/docs/v3/guides/authentication/).

### Example
```c#
// create a new client with access to the account to the auth-key owner
var client = new TwitchAuthenticatedClient("client-id", "oauth-key");

client.Follow("michidk");					// the owner of the auth-key will follow the user 'michidk'

foreach (var follower in client.GetFollowers("michidk").List)
{
    Console.WriteLine(follower.User.Name);	// print out all followers of the user 'michidk'
}
```

## Dependencies
- [RestSharp](http://restsharp.org/)
- [Json.NET](http://www.newtonsoft.com/json)

## License
Used some code from [Gibletto](https://github.com/gibletto).

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

## Misc
Created 2015 by Michael Lohr

[![Analytics](https://ga-beacon.appspot.com/UA-63472612-13/readme)](https://github.com/igrigorik/ga-beacon)
