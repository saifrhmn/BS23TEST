using BS23TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BS23TEST.Abstract
{
    public interface IBlogPostRepository
    {
        IQueryable<BlogPost> BlogPosts { get; }
        dynamic Add(dynamic _BlogPost);
        dynamic GetById(dynamic _res);
        dynamic User(dynamic _UserId);
    }
}