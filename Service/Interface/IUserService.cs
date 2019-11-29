using MyBlog.Models;
using MyBlog.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Service.Interface
{
    public interface IUserService
    {
        List<Users> GetAllUsers();
        List<Users> GetAllUsersNotFreeze();
        Users GetUserByUserId(string userId);
        public int GetUserStatus(Users user);
        public bool IsAdmin(Users user);
        bool Login(UsersDTO usersDTO);
        bool Register(Users user);
        int UpdateUser(Users user);
        int FreezeUser(string userId);
        int UnFreezeUser(string userId);
    }
}
