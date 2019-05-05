using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Article
{
    public abstract class ArticleBase
    {

        [JsonProperty("title")]
        [Required]
        public string Title { get; set; }
        [JsonProperty("content")]
        [Required]
        public string Content { get; set; }


    }
}
