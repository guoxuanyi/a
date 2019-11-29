using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Respostery.IRespostery
{
    public interface IUserRepository
    {
        List<Users> GetAllUsers();
        List<Users> GetAllUsersNotDelete();
        Users GetUserByUserId(string userId);
        Users GetUserByUserNameAndPassword(string userName, string passWord);
        bool IsUserNameExist(string userName);
        bool Register(Users user);
        int UpdateUser(Users user);
        int FreezeUser(string userId);
        int UnFreezeUser(string userId);
    }
}
