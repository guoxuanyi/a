using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository.IRepository
{
    public interface IUserBlogRelationRepository
    {
        UserBlogRelation GetRelationByUserId(string userId);
        int BlogIdExistCount(string blogId);
    }
}
