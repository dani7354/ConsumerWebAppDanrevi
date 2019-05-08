using System;
using Newtonsoft.Json;

namespace Models.Login
{
    public class LoginViewModel
    {
      [JsonProperty("email")]
       public string Email { get; set; }
      [JsonProperty("password")]
       public string Password { get; set; }
    }
}
