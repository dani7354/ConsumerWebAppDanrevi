using System;
using Newtonsoft.Json;

namespace Models.Login
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
