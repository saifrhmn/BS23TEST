using BS23TEST.Abstract;
using BS23TEST.DAL;
using BS23TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BS23TEST.Concrete
{
    public class RegistrationRepository : IRegistrationRepository, IDisposable
    {
        private APPContext _Context;
        public RegistrationRepository()
        {
            _Context = new APPContext();
        }
        public IQueryable<User> Users
        {
            get { return _Context.Users; }
        }
        void IRegistrationRepository.NewRegistration(dynamic _User)
        {
            _Context.Users.Add(new User()
            {
                UserId = Guid.NewGuid(),
                FullName = _User.FullName,
                Email = _User.Email,
                Password = _User.Password,
                Image = _User.Image,
                DOB = _User.DOB == "" ?null: _User.DOB
            });
            _Context.SaveChanges();
        }
        public void Dispose()
        {
            _Context.Dispose();
            _Context = null;
        }
    }
}