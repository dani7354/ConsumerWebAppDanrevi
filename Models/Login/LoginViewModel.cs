using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Models.Login
{
    public class LoginViewModel
    {
      [JsonProperty("email")]
      [Required]
      [EmailAddress]
       public string Email { get; set; }
      [JsonProperty("password")]
       [Required]
       public string Password { get; set; }
    }
}
