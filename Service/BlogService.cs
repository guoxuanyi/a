using MyBlog.Models;
using MyBlog.Repository.IRepository;
using MyBlog.Service.Interface;
using MyBlog.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class BlogService : DataFactory, IBlogService
    {
        public bool AddBlog(Blog blog, string userId)
        {
            int count = GetRepository<IBlogRepository>().AddBlog(blog, userId);
            if (count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int DeleteBlog(string blogId)
        {
            return GetRepository<IBlogRepository>().DeleteBlog(blogId);
        }

        public int ReDeleteBlog(string blogId)
        {
            return GetRepository<IBlogRepository>().ReDeleteBlog(blogId);
        }

        public List<Blog> GetAllBlogs()
        {
            return GetRepository<IBlogRepository>().GetAllBlogs();
        }

        public List<Blog> GetAllBlogsNotDelete()
        {
            return GetRepository<IBlogRepository>().GetAllBlogsNotDelete();
        }

        public List<Blog> GetBlogsByUserId(string userId)
        {
            return GetRepository<IBlogRepository>().GetBlogsByUserId(userId);
        }

        public List<Blog> GetBlogsNotDeleteByUserName(string userName)
        {
            return GetRepository<IBlogRepository>().GetBlogsNotDeleteByUserName(userName);
        }

        public List<Blog> GetDeletedBlogs()
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetNotDeleteBlogsTop4()
        {
            List<Blog> blogs = GetRepository<IBlogRepository>().GetNotDeleteBlogsTop4();
            if (blogs.Count>=4)
            {
                return blogs.Take(4).ToList();
            }
            else
            {
                return blogs;
            }
        }

        public int UpdateBlog(Blog blog, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
