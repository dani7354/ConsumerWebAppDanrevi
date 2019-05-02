using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Article
{
    public class ArticleDetailsViewModel : ArticleBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("author")]
        public Author Author { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }
    }
}
