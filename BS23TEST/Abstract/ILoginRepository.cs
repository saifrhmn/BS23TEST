using BS23TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BS23TEST.Abstract
{
    public interface ILoginRepository
    {
        IQueryable<User> Users { get; }
        dynamic AuthenticUser(dynamic res);
    }
}