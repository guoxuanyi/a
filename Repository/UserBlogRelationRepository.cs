using MyBlog.Models;
using MyBlog.Repository.IRepository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Repository
{
    public class UserBlogRelationRepository : DataFactory, IUserBlogRelationRepository
    {
        public UserBlogRelation GetRelationByUserId(string userId)
        {
            UserBlogRelation relation = Db.UserBlogRelation.AsNoTracking().FirstOrDefault(ubr => ubr.UserId == userId);
            return relation;
        }

        public int BlogIdExistCount(string blogId)
        {
            int count = Db.UserBlogRelation.AsNoTracking().Where(ubr => ubr.BlogId == blogId).ToList().Count;
            return count;
        }

    }
}
