using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]

    public class BlogController : DataFactory
    {
        [HttpGet("api/v{version:ApiVersion}/Blog/blogs")]
        public List<Blog> GetAllBlogs()
        {
            return GetService<IBlogService>().GetAllBlogs();
        }

        [HttpGet("api/v{version:ApiVersion}/Blog/undelete-blogs")]
        public List<Blog> GetAllBlogsNotDelete()
        {
            return GetService<IBlogService>().GetAllBlogsNotDelete();
        }

        [HttpGet("api/v{version:ApiVersion}/Blog/top4-undelete-blogs")]
        public List<Blog> GetNotDeleteBlogsTop4()
        {
            return GetService<IBlogService>().GetNotDeleteBlogsTop4();
        }

        [HttpGet]
        [Route("api/Blog/getBlogsByUserId")]
        public List<Blog> GetBlogsByUserId(string userId)
        {
            return GetService<IBlogService>().GetBlogsByUserId(userId);
        }

        [HttpGet]
        [Route("api/Blog/getBlogsNotDeleteByUserName")]
        public List<Blog> GetBlogsNotDeleteByUserName(string userName)
        {
            return GetService<IBlogService>().GetBlogsNotDeleteByUserName(userName);
        }

        [HttpPost]
        [Route("api/Blog/addBlog")]
        public bool AddBlog(Blog blog, string userId)
        {
            return GetService<IBlogService>().AddBlog(blog, userId);
        }

        [HttpPost]
        [Route("api/Blog/deleteBlog")]
        public int DeleteBlog(string blogId)
        {
            return GetService<IBlogService>().DeleteBlog(blogId);
        }

        [HttpPost]
        [Route("api/Blog/reDeleteBlog")]
        public int ReDeleteBlog(string blogId)
        {
            return GetService<IBlogService>().ReDeleteBlog(blogId);
        }

        [HttpGet("api/v{version:ApiVersion}/Blog/blogLikeCount-update/{blogId}")]
        public int UpdateblogLikeCount(string blogId)
        {
            return GetService<IBlogService>().UpdateBlogLikeCount(blogId);
        }
    }
}
