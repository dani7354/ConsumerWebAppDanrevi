using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string TagString { get; set; }
    }
}
