using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Article
{
    public class ArticleDetailsViewModel : ArticleBase
    {
        [JsonProperty("author")]
        public Author Author { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
