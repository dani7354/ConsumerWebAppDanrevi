﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Article
{
    
    public class Author
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
