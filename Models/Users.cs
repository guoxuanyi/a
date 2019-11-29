using System;
using System.Collections.Generic;

namespace MyBlog.Models
{
    public partial class Users
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoto { get; set; }
        public DateTime UserRegisterDate { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserNickname { get; set; }
        public int Admin { get; set; }
        public int UserDeleteFlag { get; set; }
    }
}
