using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Service.Interface
{
    public interface IBlogService
    {
        List<Blog> GetAllBlogs();
        List<Blog> GetAllBlogsNotDelete();
        List<Blog> GetDeletedBlogs();
        List<Blog> GetBlogsByUserId(string userId);
        List<Blog> GetBlogsNotDeleteByUserName(string userName);
        List<Blog> GetNotDeleteBlogsTop4();
        bool AddBlog(Blog blog, string userId);
        int DeleteBlog(string blogId);
        int ReDeleteBlog(string blogId);
        int UpdateBlog(Blog blog, string userId);
        int UpdateBlogLikeCount(string blogId);
    }
}
