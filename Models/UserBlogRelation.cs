using System;
using System.Collections.Generic;

namespace MyBlog.Models
{
    public partial class UserBlogRelation
    {
        public string UserId { get; set; }
        public string BlogId { get; set; }
    }
}
