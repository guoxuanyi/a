using MyBlog.Models;
using MyBlog.Respostery.IRespostery;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Repository
{
    public class UserRepository : DataFactory, IUserRepository
    {
        public List<Users> GetAllUsers()
        {
            List<Users> users = Db.Users.AsNoTracking().ToList();
            return users;
        }

        public List<Users> GetAllUsersNotDelete()
        {
            List<Users> users = Db.Users.AsNoTracking().Where(u => u.UserDeleteFlag != 1).ToList();
            return users;
        }

        public Users GetUserByUserId(string userId)
        {
            Users user = Db.Users.AsNoTracking().FirstOrDefault(u => u.UserId == userId);
            return user;
        }

        public Users GetUserByUserNameAndPassword(string userName, string passWord)
        {
            Users user = Db.Users.AsNoTracking().FirstOrDefault(u => u.UserName == userName && u.UserPassword == passWord);
            return user;
        }

        public bool IsUserNameExist(string userName)
        {
            int count = Db.Users.AsNoTracking().Where(u => u.UserName == userName).ToList().Count;
            return count == 0 ? false : true;
        }

        public int UpdateUser(Users user)
        {
            Db.Update(user);
            return Db.SaveChanges();
        }

        public bool Register(Users user)
        {
            user.UserId = Guid.NewGuid().ToString().ToUpper();
            Db.Users.Add(user);
            int count = Db.SaveChanges();
            return count == 1 ? true : false;
        }

        public int FreezeUser(string userId)
        {
            var user = Db.Users.FirstOrDefault(u => u.UserId == userId);
            user.UserDeleteFlag = 1;
            return Db.SaveChanges();
        }

        public int UnFreezeUser(string userId)
        {
            var user = Db.Users.FirstOrDefault(u => u.UserId == userId);
            user.UserDeleteFlag = 0;
            return Db.SaveChanges();
        }
    }
}
