using MyBlog.Models;
using MyBlog.Models.DTO;
using MyBlog.Repository;
using MyBlog.Respostery.IRespostery;
using MyBlog.Service.Interface;
using MyBlog.Tool;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Service
{
    public class UserService : DataFactory, IUserService
    {

        /// <summary>
        /// 管理员操作：获取所有用户(包括冻结)
        /// </summary>
        /// <returns>用户列表</returns>
        public List<Users> GetAllUsers()
        {
            return GetRepository<IUserRepository>().GetAllUsers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Users> GetAllUsersNotFreeze()
        {
            return GetRepository<IUserRepository>().GetAllUsersNotDelete();
        }

        /// <summary>
        /// 共通操作：根据用户ID找到该用户
        /// </summary>
        /// <param name="userId">http请求发送用户ID</param>
        /// <returns>用户</returns>
        public Users GetUserByUserId(string userId)
        {
            return GetRepository<IUserRepository>().GetUserByUserId(userId);
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName">HTTP请求发送用户ID</param>
        /// <returns>是否存在</returns>
        public bool IsUserNameExist(string userName)
        {
            return GetRepository<IUserRepository>().IsUserNameExist(userName);
        }

        public Users GetUserByUserNameAndPassword(string userName, string passWord)
        {
            return GetRepository<IUserRepository>().GetUserByUserNameAndPassword(userName, passWord);
        }

        public int GetUserStatus(Users user)
        {
            int status = user.UserDeleteFlag;
            return status;
        }

        public bool IsAdmin(Users user)
        {
            bool userIsTrue = Tools.IsNull(user);
            if (!userIsTrue && user.Admin == 1)
            {
                return !userIsTrue;
            }
            else
            {
                return userIsTrue;
            }
        }

        /// <summary>
        /// 关联GetUserByUserNameAndPassword，IsAdmin，GetUserStatus三个方法获取登录状态
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns>登录状态</returns>
        public string SignIn(UsersDTO usersDTO)
        {
            Users user = GetUserByUserNameAndPassword(usersDTO.UserName, usersDTO.UserPassword);
            if (!Tools.IsNull(user) && IsAdmin(user))
            {
                return "Admin signin";
            }
            else if (!Tools.IsNull(user) && !IsAdmin(user) && GetUserStatus(user) == 0)
            {
                return "User signin";
            }
            else if (!Tools.IsNull(user) && !IsAdmin(user) && GetUserStatus(user) != 0)
            {
                return "User is frozen";
            }
            return "Not found";
            //if (!Tools.IsNull(user))
            //{
            //    bool isAdmin = IsAdmin(user);
            //    if (!isAdmin)
            //    {
            //        int userStatus = GetUserStatus(user);
            //        if (userStatus == 0)
            //        {
            //            return "User signin";
            //        }
            //        else
            //        {
            //            return "User is frozen";
            //        }
            //    }
            //    else
            //    {
            //        return "Admin signin";
            //    }
            //}
            //else
            //{
            //    return "Not found";
            //}

        }

        /// <summary>
        /// 用户操作：注册
        /// </summary>
        /// <param name="user">http请求发送的信息</param>
        /// <returns>注册结果</returns>
        public bool SignUp(Users user)
        {
            bool isUserNameExist = IsUserNameExist(user.UserName);
            if (!isUserNameExist)
            {
                return GetRepository<IUserRepository>().Register(user);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 管理员操作：冻结账户
        /// </summary>
        /// <param name="userId">客户端发送的用户Id</param>
        /// <returns>返回受影响的用户数量</returns>
        public int FreezeUser(string userId)
        {
            return GetRepository<IUserRepository>().FreezeUser(userId);
        }

        public int UpdateUser(Users user)
        {
            bool status = IsUserNameExist(user.UserName);
            if (!status)
            {
                return GetRepository<IUserRepository>().UpdateUser(user);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 管理员操作：解冻账户
        /// </summary>
        /// <param name="userId">客户端发送的用户Id</param>
        /// <returns>返回受影响的用户数量</returns>
        public int UnFreezeUser(string userId)
        {
            return GetRepository<IUserRepository>().UnFreezeUser(userId);
        }

        public List<string> GetUserIcon(List<string> userId)
        {
            return GetRepository<IUserRepository>().GetUserIcon(userId);
        }
    }
}
