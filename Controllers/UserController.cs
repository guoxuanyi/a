using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Models.DTO;
using MyBlog.Service;
using MyBlog.Service.Interface;
using System.Collections.Generic;

namespace MyBlog.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]

    public class UserController : DataFactory
    {
        [HttpGet("api/v{version:ApiVersion}/User/users")]
        public List<Users> GetAllUsers()
        {
            return GetService<IUserService>().GetAllUsers();
        }

        [HttpGet("api/v{version:ApiVersion}/User/users-unFreeze")]
        public List<Users> GetAllUsersNotFreeze()
        {
            return GetService<IUserService>().GetAllUsersNotFreeze();
        }

        [HttpGet("api/v{version:ApiVersion}/User/users/{userId}")]
        public Users GetUserByUserId(string userId)
        {
            return GetService<IUserService>().GetUserByUserId(userId);
        }

        [HttpPost("api/v{version:ApiVersion}/User/login")]
        public bool Login(UsersDTO usersDTO)
        {
            return GetService<IUserService>().Login(usersDTO);
        }

        [HttpPost("api/v{version:ApiVersion}/User/register")]
        public bool Register(Users user)
        {
            return GetService<IUserService>().Register(user);
        }

        [HttpGet("api/v{version:ApiVersion}/User/users-freeze/{userId}")]
        public int FreezeUser(string userId)
        {
            return GetService<IUserService>().FreezeUser(userId);
        }

        [HttpGet("api/v{version:ApiVersion}/User/users-unFreeze/{userId}")]
        public int UnFreezeUser(string userId)
        {
            return GetService<IUserService>().UnFreezeUser(userId);
        }

        [HttpPut("api/v{version:ApiVersion}/User/update")]
        public int UpdateUser(Users user)
        {
            return GetService<IUserService>().UpdateUser(user);
        }
    }
}
