using MyBlog.Models;
using MyBlog.Repository;
using MyBlog.Repository.IRepository;
using MyBlog.Respostery.IRespostery;
using MyBlog.Service;
using MyBlog.Service.Interface;
using MyBlog.Tool;

namespace MyBlog
{
    public class DataFactory
    {
        private static gxyContext db;
        public static gxyContext Db
        {
            get
            {
                if (Tools.IsNull(db))
                {
                    db = new gxyContext();
                }
                return db;
            }
        }

        public T GetRepository<T>()
        {
            if (typeof(T) == typeof(IUserRepository))
            {
                object instance = new UserRepository();
                return (T)instance;
            }
            else if (typeof(T) == typeof(ISortRepository))
            {
                object instance = new SortRepository();
                return (T)instance;
            }
            else if (typeof(T) == typeof(IBlogRepository))
            {
                object instance = new BlogRepository();
                return (T)instance;
            }
            else if (typeof(T) == typeof(IUserBlogRelationRepository))
            {
                object instance = new UserBlogRelationRepository();
                return (T)instance;
            }
            else
            {
                return default(T);
            }
        }

        public T GetService<T>()
        {
            if (typeof(T) == typeof(ISortService))
            {
                object instance = new SortService();
                return (T)instance;
            }
            else if (typeof(T) == typeof(IUserService))
            {
                object instance = new UserService();
                return (T)instance;
            }
            else if (typeof(T) == typeof(IBlogService))
            {
                object instance = new BlogService();
                return (T)instance;
            }
            else
            {
                return default(T);
            }
        }
    }
}
