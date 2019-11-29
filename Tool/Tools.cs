using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Tool
{
    public static class Tools
    {
        public static bool IsNull<T>(T obj) where T : class
        {
            return obj == null;
        }
    }
}
