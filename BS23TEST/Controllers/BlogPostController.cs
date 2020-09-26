using BS23TEST.Abstract;
using BS23TEST.Concrete;
using BS23TEST.DAL;
using BS23TEST.Infrastructure;
using BS23TEST.Models;
using BS23TEST.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BS23TEST.Controller
{
    public class BlogPostController : ApiController
    {
        private IBlogPostRepository repository;
        private Response _Response;
        public BlogPostController()
        {
            repository = new BlogPostRepository();
            _Response = new Response();
        }
        public BlogPostController(IBlogPostRepository blogPostRepository)
        {
            repository = blogPostRepository;
        }

       

       

        [HttpPost]
        public dynamic UserBlogPost(dynamic UserId)
        {
            try
            {
                _Response.Data = repository.User(UserId);
                _Response.Message = "Success";
                _Response.Status = 1;
            }
            catch (Exception ex)
            {
                _Response.Data = null;
                _Response.Message = ex.Message.ToString();
                _Response.Status = 0;
            }
            return _Response;
        }

        [HttpPost]
        public dynamic CreateNewEvent(dynamic res)
        {
            string EventId = res.EventId.ToString();
            try
            {
                if (res.EventId.ToString() == "")
                {
                    _Response.Data = repository.Add(res);
                }
               
                _Response.Message = "Success";
                _Response.Status = 1;
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