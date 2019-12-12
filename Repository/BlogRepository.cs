using MyBlog.Models;
using MyBlog.Repository.IRepository;
using MyBlog.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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
            Blog blog = GetBlogByBlogId(blogId);
            blog.BlogDeleteFlag = 1;
            return Db.SaveChanges();
        }

        public int ReDeleteBlog(string blogId)
        {
            Blog blog = GetBlogByBlogId(blogId);
            blog.BlogDeleteFlag = 0;
            return Db.SaveChanges();
        }

        public List<Blog> GetAllBlogs()
        {
            string sql = "select * from Blog";
            List<Blog> blogs = Db.Blog.FromSqlRaw(sql).ToList();
            return blogs;
        }

        public List<Blog> GetAllBlogsNotDelete()
        {
            string sql = "select * from Blog where blog_delete_flag <> 1";
            List<Blog> blogs = Db.Blog.FromSqlRaw(sql).ToList();
            return blogs;
        }

        public List<Blog> GetBlogsByUserId(string userId)
        {
            string sql = "select user_id, blog_id from UserBlogRelation where user_id = @userId";
            SqlParameter param = new SqlParameter("@userId", userId);
            List<UserBlogRelation> relation = Db.UserBlogRelation.FromSqlRaw(@sql, param).ToList();
            List<Blog> blogs = new List<Blog>();
            foreach (var item in relation)
            {
                Blog blog = GetBlogByBlogId(item.BlogId);
                blogs.Add(blog);
            }
            return blogs;
        }

        public List<Blog> GetBlogsNotDeleteByUserName(string userName)
        {
            string userSql = "select user_id,user_name,user_password,user_email,user_photo,user_register_date," +
                "user_phone_number,user_nickname,admin,user_delete_flag " +
                "from Users where user_name = @userName";
            SqlParameter userParam = new SqlParameter("@userName", userName);
            Users user = Db.Users.FromSqlRaw(@userSql, userParam).FirstOrDefault();
            List<Blog> blogs = new List<Blog>();
            if (!Tools.IsNull(user))
            {
                string relationsql = "select user_id, blog_id from UserBlogRelation where user_id = @userId";
                SqlParameter relationparam = new SqlParameter("@userId", user.UserId);
                List<UserBlogRelation> relation = Db.UserBlogRelation.FromSqlRaw(@relationsql, relationparam).ToList();
                foreach (var item in relation)
                {
                    string blogSql = "select blog_id, blog_title, blog_content, blog_views, blog_comment_count, " +
                        "blog_date, blog_like_count, blog_delete_flag " +
                        "from Blog where blog_id = @blogId and blog_delete_flag <> 1";
                    SqlParameter blogParam = new SqlParameter("@blogId", item.BlogId);
                    Blog blog = Db.Blog.FromSqlRaw(@blogSql, blogParam).FirstOrDefault();
                    blogs.Add(blog);
                }
            }
            return blogs;
        }

        public List<Blog> GetDeletedBlogs()
        {
            string sql = "select blog_id, blog_title, blog_content, blog_views, blog_comment_count, " +
                "blog_date, blog_like_count, blog_delete_flag from Blog where blog_delete_flag == 1";
            List<Blog> blogs = Db.Blog.FromSqlRaw(sql).ToList();
            return blogs;
        }

        public int UpdateBlog(Blog blog, string userId)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetNotDeleteBlogsTop4()
        {
            string sql = "select blog_id, blog_title, blog_content, blog_views, blog_comment_count, " +
                        "blog_date, blog_like_count, blog_delete_flag " +
                        "from Blog where blog_delete_flag <> 1 order by blog_views desc";
            List<Blog> blogs = Db.Blog.FromSqlRaw(sql).ToList();
            return blogs;
        }

        public int UpdateBlogLikeCount(string blogId)
        {
            string sql = "select blog_id, blog_title, blog_content, blog_views, blog_comment_count, " +
                        "blog_date, blog_like_count, blog_delete_flag " +
                        "from Blog where blog_id = @blogId and blog_delete_flag <> 1";
            SqlParameter param = new SqlParameter("@blogId", blogId);
            Blog blog = Db.Blog.FromSqlRaw(@sql, param).FirstOrDefault();
            blog.BlogLikeCount += 1;
            return Db.SaveChanges();
        }

        public Blog GetBlogByBlogId(string blogId)
        {
            string sql = "select blog_id, blog_title, blog_content, blog_views, blog_comment_count, " +
                "blog_date, blog_like_count, blog_delete_flag from Blog where blog_id = @blogId";
            SqlParameter param = new SqlParameter("@blogId", blogId);
            Blog blog = Db.Blog.FromSqlRaw(@sql, param).FirstOrDefault();
            return blog;
        }
    }
}
