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
        string SignIn(UsersDTO usersDTO);
        bool SignUp(Users user);
        int UpdateUser(Users user);
        int FreezeUser(string userId);
        int UnFreezeUser(string userId);
        List<string> GetUserIcon(List<string> userId);

    }
}
