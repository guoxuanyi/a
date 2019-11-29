using System;
using System.Collections.Generic;

namespace MyBlog.Models
{
    public partial class Blog
    {
        public string BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public long BlogViews { get; set; }
        public long BlogCommentCount { get; set; }
        public DateTime BlogDate { get; set; }
        public long BlogLikeCount { get; set; }
        public int BlogDeleteFlag { get; set; }
    }
}
