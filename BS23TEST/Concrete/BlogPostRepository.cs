using BS23TEST.Abstract;
using BS23TEST.DAL;
using BS23TEST.Models;
using BS23TEST.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace BS23TEST.Concrete
{
    public class BlogPostRepository : IBlogPostRepository, IDisposable
    {
        private APPContext _Context;
        public BlogPostRepository()
        {
            _Context = new APPContext();
        }
        public IQueryable<BlogPost> BlogPosts
        {
            get { return _Context.BlogPosts; }
        }
        dynamic IBlogPostRepository.GetById(dynamic PostID)
        {
            Guid _PostID = new Guid(PostID.PostID.ToString());
            BlogPost _BlogPost = _Context.BlogPosts.Where(p => p.PostID == _PostID)
                                            .FirstOrDefault<BlogPost>();
            return JsonConvert.SerializeObject(_BlogPost);
        }
        dynamic IBlogPostRepository.User(dynamic UserId)
        {
            int ?Page_No = 0;
            //if (Search_Data != null)
            //{
            //    Page_No = 1;
            //}
            //else
            //{
            //    Search_Data = Filter_Value;
            //}

            //ViewBag.FilterValue = Search_Data;


            Guid _UserId = new Guid(UserId.UserId.ToString());
            List<BlogPostViewModel> blogPostsList = new List<BlogPostViewModel>();
            List<BlogPost> blogPosts = new List<BlogPost>();

            blogPosts = _Context.BlogPosts.Where(p => p.UserId == _UserId)
                                            .OrderByDescending(p => p.PostTime)
                                            .OrderByDescending(p => p.Date)
                                            .ToList<BlogPost>();
            foreach (BlogPost e in blogPosts)
            {
                groupByDate(blogPostsList, e);
            }
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return JsonConvert.SerializeObject(blogPostsList.ToPagedList(No_Of_Page,Size_Of_Page));
        }
        dynamic IBlogPostRepository.Add(dynamic _BlogPost)
        {
            TimeSpan PostTime = new TimeSpan(0, 0, 0);
            DateTime Date = DateTime.Now;
            try
            {
                PostTime = new TimeSpan(Int32.Parse(_BlogPost.Start.hour.ToString()), 
                    Int32.Parse(_BlogPost.Start.minute.ToString()), 0);
                Date = Convert.ToDateTime(_BlogPost.Date.ToString());
            }
            catch (Exception) { }

            _Context.BlogPosts.Add(new BlogPost()
            {
                PostID = Guid.NewGuid(),
                UserId = new Guid(_BlogPost.UserId.ToString()),
                Title = _BlogPost.Title,
                Description = _BlogPost.Description,
                Date = Date.Date,
                PostTime = PostTime,
                Location = _BlogPost.Location
            });
            _Context.SaveChanges();

            return null;
        }
        public void groupByDate(List<BlogPostViewModel> blogPostList, BlogPost blogPostObj)
        {
            BlogPostViewModel record = blogPostList.Where(p => p.Date == blogPostObj.Date).FirstOrDefault<BlogPostViewModel>();
            if (record == null)
            {
                blogPostList.Add(new BlogPostViewModel()
                {
                    Date = blogPostObj.Date,
                    DateStringFormat = blogPostObj.Date.ToString("dddd,  MMMM dd"),
                    BlogPosts = new List<BlogPost>() { blogPostObj }
                });
            }
            else
            {
                record.BlogPosts.Add(blogPostObj);
            }
        }
        public void Dispose()
        {
            _Context.Dispose();
            _Context = null;
        }
    }
}