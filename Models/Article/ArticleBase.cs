using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Article
{
    public abstract class ArticleBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

    }
}
