using BS23TEST.Abstract;
using BS23TEST.Concrete;
using BS23TEST.DAL;
using BS23TEST.Infrastructure;
using BS23TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BS23TEST.Controller
{
    public class RegisterController: ApiController
    {
        private IRegistrationRepository repository;
        private Response _Response;
        public RegisterController()
        {
            repository = new RegistrationRepository();
            _Response = new Response();
        }
        public RegisterController(IRegistrationRepository registrationRepository)
        {
            repository = registrationRepository;
        }
        [HttpPost]
        public dynamic NewRegistration(dynamic _User)
        {
            try
            {
                repository.NewRegistration(_User);
                _Response.Data = "";
                _Response.Message = "Success";
                _Response.Status = 0;
            }
            catch (Exception ex)
            {
                _Response.Data = null;
                _Response.Message = ex.Message.ToString();
                _Response.Status = 0;
            }
            return _Response;
        }
    }
}