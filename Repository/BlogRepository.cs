using MyBlog.Models;
using MyBlog.Repository.IRepository;
using MyBlog.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Repository
{
    public class BlogRepository : DataFactory, IBlogRepository
    {
        public int AddBlog(Blog blog, string userId)
        {
            blog.BlogId = Guid.NewGuid().ToString().ToUpper();
            Db.Blog.Add(blog);
            UserBlogRelation relation = new UserBlogRelation();
            relation.UserId = userId;
            relation.BlogId = blog.BlogId;
            Db.UserBlogRelation.Add(relation);
            return Db.SaveChanges();
        }

        public int DeleteBlog(string blogId)
        {
            Blog blog = Db.Blog.FirstOrDefault(b => b.BlogId == blogId);
            blog.BlogDeleteFlag = 1;
            return Db.SaveChanges();
        }

        public int ReDeleteBlog(string blogId)
        {
            Blog blog = Db.Blog.FirstOrDefault(b => b.BlogId == blogId);
            blog.BlogDeleteFlag = 0;
            return Db.SaveChanges();
        }

        public List<Blog> GetAllBlogs()
        {
            List<Blog> blogs = Db.Blog.AsNoTracking().ToList();
            return blogs;
        }

        public List<Blog> GetAllBlogsNotDelete()
        {
            List<Blog> blogs = Db.Blog.AsNoTracking().Where(b => b.BlogDeleteFlag != 1).ToList();
            return blogs;
        }

        public List<Blog> GetBlogsByUserId(string userId)
        {
            List<UserBlogRelation> relation = Db.UserBlogRelation.AsNoTracking().Where(ubr => ubr.UserId == userId).ToList();
            List<Blog> blogs = new List<Blog>();
            foreach (var item in relation)
            {
                Blog blog = Db.Blog.AsNoTracking().FirstOrDefault(b => b.BlogId == item.BlogId);
                blogs.Add(blog);
            }
            return blogs;
        }

        public List<Blog> GetBlogsNotDeleteByUserName(string userName)
        {
            Users user = Db.Users.AsNoTracking().FirstOrDefault(u => u.UserName == userName);
            List<Blog> blogs = new List<Blog>();
            if (Tools.IsNull(user))
            {
                return blogs;
            }
            else
            {
                List<UserBlogRelation> relation = Db.UserBlogRelation.AsNoTracking().Where(ubr => ubr.UserId == user.UserId).ToList();
                foreach (var item in relation)
                {
                    Blog blog = Db.Blog.AsNoTracking().FirstOrDefault(b => b.BlogId == item.BlogId && b.BlogDeleteFlag != 1);
                    blogs.Add(blog);
                }
                return blogs;
            }
        }

        public List<Blog> GetDeletedBlogs()
        {
            List<Blog> blogs = Db.Blog.AsNoTracking().Where(b => b.BlogDeleteFlag == 1).ToList();
            return blogs;
        }

        public int UpdateBlog(Blog blog, string userId)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetNotDeleteBlogsTop4()
        {
            List<Blog> blogs = Db.Blog.AsNoTracking().Where(b => b.BlogDeleteFlag != 1).OrderByDescending(b => b.BlogViews).ToList();
            return blogs;
        }

        public int UpdateBlogLikeCount(string blogId)
        {
            Blog blog = Db.Blog.Where(b => b.BlogDeleteFlag!=1).FirstOrDefault(b => b.BlogId == blogId);
            blog.BlogLikeCount += 1;
            return Db.SaveChanges();
        }
    }
}
