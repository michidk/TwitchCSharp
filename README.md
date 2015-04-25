# Twitch C# Wrapper for the Twitch v3 REST API

##Documentation: 
https://github.com/justintv/Twitch-API


##Example:
```c
TwitchConnection conn = new TwitchConnection(name, clientId, oAuthToken);
TwitchAuthenticatedClient client = new TwitchAuthenticatedClient(conn);

client.Follow("michidk");

foreach (Follower follower in client.GetFollowers("michidk").List)
{
    Console.WriteLine(follower.User.Name);
}
```

##used .dll's:
http://restsharp.org/
http://www.newtonsoft.com/json


Used structure and some code from https://github.com/gibletto


   Copyright 2015 michidk

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
