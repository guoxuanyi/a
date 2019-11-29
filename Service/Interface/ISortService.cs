using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Service.Interface
{
    public interface ISortService 
    {
        List<Sort> GetAllSorts();
        Sort GetSortBySortId(string sortId);
        bool AddSort(Sort sort);
        int DeleteSort(string sortId);
        int UpdateSort(Sort sort);
    }
}
