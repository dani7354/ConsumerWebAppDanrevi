using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Article
{
    public class ArticleCreateViewModel : ArticleBase
    {
        [JsonProperty("tags")]
        public string Tags { get; set; }
    }
}
