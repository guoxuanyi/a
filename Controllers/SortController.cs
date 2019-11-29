using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Service;
using MyBlog.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [ApiController]

    public class SortController : DataFactory
    {
        [HttpPost]
        [Route("api/Sort/getAllSorts")]
        public List<Sort> GetAllSorts()
        {
            return GetService<ISortService>().GetAllSorts();
        }

        [HttpGet]
        [Route("api/Sort/getSortById")]
        public Sort GetSortById(string sortId)
        {
            return GetService<ISortService>().GetSortBySortId(sortId);
        }

        [HttpPost]
        [Route("api/Sort/addSort")]
        public bool AddSort(Sort sort)
        {
            return GetService<ISortService>().AddSort(sort);
        }

        [HttpDelete]
        [Route("api/Sort/deleteSort")]
        public int DeleteSort(string sortId)
        {
            return GetService<ISortService>().DeleteSort(sortId);
        }

        [HttpPut]
        [Route("api/Sort/updateSort")]
        public int UpdateSort(Sort sort)
        {
            return GetService<ISortService>().UpdateSort(sort);
        }
    }
}
