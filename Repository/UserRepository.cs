using MyBlog.Models;
using MyBlog.Respostery.IRespostery;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MyBlog.Repository
{
    public class UserRepository : DataFactory, IUserRepository
    {
        public List<Users> GetAllUsers()
        {
            string sql = "select * from Users";
            List<Users> users = Db.Users.FromSqlRaw(sql).ToList();
            return users;
        }

        public List<Users> GetAllUsersNotDelete()
        {
            string sql = "select * from Users where user_delete_flag <> 1";
            List<Users> users = Db.Users.FromSqlRaw(sql).ToList();
            return users;
        }

        public Users GetUserByUserId(string userId)
        {
            string sql = "select * from Users where user_id = @userId";
            SqlParameter param = new SqlParameter("@userId", userId);
            Users user = Db.Users.FromSqlRaw(@sql, param).FirstOrDefault();
            return user;
        }

        public Users GetUserByUserNameAndPassword(string userName, string passWord)
        {
            string sql = "select * from Users where user_name = @userName and user_password = @userPassword";
            SqlParameter param1 = new SqlParameter("@userName", userName);
            SqlParameter param2 = new SqlParameter("@userPassword", passWord);
            Users user = Db.Users.FromSqlRaw(@sql, param1, param2).FirstOrDefault();
            return user;
        }

        public bool IsUserNameExist(string userName)
        {
            string sql = "select * from Users where user_name = @userName";
            SqlParameter param = new SqlParameter("@userName", userName);
            int count = Db.Users.FromSqlRaw(@sql, param).ToList().Count;
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
            Users user = GetUserByUserId(userId);
            user.UserDeleteFlag = 1;
            return Db.SaveChanges();
        }

        public int UnFreezeUser(string userId)
        {
            Users user = GetUserByUserId(userId);
            user.UserDeleteFlag = 0;
            return Db.SaveChanges();
        }

        public List<string> GetUserIcon(List<string> userIdList)
        {
            string sql = "select * from Users where user_id in @userIdList and user_delete_flag <> 1";
            SqlParameter param = new SqlParameter("@userIdList", userIdList);
            List<Users> users = Db.Users.FromSqlRaw(@sql, param).ToList();
            List<string> userIcons = new List<string>();
            foreach (var item in userIcons)
            {
                userIcons.Add(item);
            }
            return userIcons;
        }
    }
}
