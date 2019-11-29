using MyBlog.Models;
using MyBlog.Repository;
using MyBlog.Repository.IRepository;
using MyBlog.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class SortService : DataFactory, ISortService
    {

        public bool AddSort(Sort sort)
        {
            return GetRepository<ISortRepository>().AddSort(sort);
        }

        public int DeleteSort(string sortId)
        {
            return GetRepository<ISortRepository>().DeleteSort(sortId);
        }

        public List<Sort> GetAllSorts()
        {
            return GetRepository<ISortRepository>().GetAllSorts();
        }

        public Sort GetSortBySortId(string sortId)
        {
            return GetRepository<ISortRepository>().GetSortBySortId(sortId);
        }

        public int UpdateSort(Sort sort)
        {
            return GetRepository<ISortRepository>().UpdateSort(sort);
        }
    }
}
