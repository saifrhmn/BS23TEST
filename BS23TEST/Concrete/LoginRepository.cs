using BS23TEST.Abstract;
using BS23TEST.DAL;
using BS23TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BS23TEST.Concrete
{
    public class LoginRepository : ILoginRepository, IDisposable
    {
        private APPContext _Context;
        public LoginRepository()
        {
            _Context = new APPContext();
        }
        public IQueryable<User> Users
        {
            get { return _Context.Users; }
        }
        dynamic ILoginRepository.AuthenticUser(dynamic res)
        {
            string Email = res.Email.ToString();
            string Password = res.Password.ToString();
            User result = _Context.Users.Where(p => p.Email == Email && p.Password == Password).FirstOrDefault<User>();
            return result;
        }
        public void Dispose()
        {
            _Context.Dispose();
            _Context = null;
        }
    }
}