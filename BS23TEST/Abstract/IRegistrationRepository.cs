using BS23TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BS23TEST.Abstract
{
    public interface IRegistrationRepository
    {
        IQueryable<User> Users { get; }
        void NewRegistration(dynamic _User);
    }
}