using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class ArticleBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}
