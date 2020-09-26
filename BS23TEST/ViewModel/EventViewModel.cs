using BS23TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BS23TEST.ViewModel
{
    public class BlogPostViewModel
    {
        public DateTime Date { get; set; }
        public string DateStringFormat { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
    }
}