using MyBlog.Models;
using MyBlog.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyBlog.Tool;

namespace MyBlog.Repository
{
    public class SortRepository : DataFactory, ISortRepository
    {
        public bool AddSort(Sort sort)
        {
            sort.SortId = Guid.NewGuid().ToString().ToUpper();
            Db.Sort.Add(sort);
            int count = Db.SaveChanges();
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int DeleteSort(string sortId)
        {
            Sort sort = Db.Sort.FirstOrDefault(s => s.SortId == sortId);
            Db.Sort.Remove(sort);
            return Db.SaveChanges();
        }

        public List<Sort> GetAllSorts()
        {
            List<Sort> sorts = Db.Sort.AsNoTracking().ToList();
            return sorts;
        }

        public Sort GetSortBySortId(string sortId)
        {
            Sort sort = Db.Sort.AsNoTracking().FirstOrDefault(s => s.SortId == sortId);
            return sort;
        }

        public int UpdateSort(Sort sort)
        {
            Sort sortModify = Db.Sort.FirstOrDefault(s => s.SortId == sort.SortId);
            if (!Tools.IsNull(sortModify))
            {
                sortModify.SortName = sort.SortName;
                sortModify.SortDescription = sort.SortDescription;
                return Db.SaveChanges();
            }
            else
            {
                return -1;
            }
            
        }
    }
}
