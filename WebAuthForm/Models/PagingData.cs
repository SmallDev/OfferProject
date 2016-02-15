using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAuthForm.Models
{
    public class Paging
    {
        public int PageNumber { get; set; }
        public int TotalPagesCount { get; set; }
        public int PageSize { get; set; }
        public List<long> ListPageSizes { get; set; }
        
        public static Paging CreatePaging(int pageNumber, long countOffers, int pageSize,int totalPagesCount)
        {
            var paging =new Paging();
            paging.PageNumber = pageNumber;
            paging.TotalPagesCount = totalPagesCount;
            paging.PageSize = pageSize;
            paging.ListPageSizes = new List<long>();
            int i = 5;
            while (i <= countOffers)
            {
                paging.ListPageSizes.Add(i);
                i += 5;
            }
           return paging;

        }
        

    }
}