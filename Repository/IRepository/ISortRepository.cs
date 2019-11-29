using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository.IRepository
{
    public interface ISortRepository
    {
        List<Sort> GetAllSorts();
        Sort GetSortBySortId(string sortId);
        bool AddSort(Sort sort);
        int DeleteSort(string sortId);
        int UpdateSort(Sort sort);
    }
}
