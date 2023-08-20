using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class Pagination
    {
        public int PageNumber { get; private set; }
        public int TotalPage { get; private set; }
        public Pagination(int count,int pagenumber,int pagesize)
        {
            PageNumber = pagenumber;
            TotalPage= (int)Math.Ceiling(count /(double)pagesize);
        }
        public bool Increment
        {
            get { return (PageNumber > 0); }
        }
        public bool Decrement
        {
            get { return (PageNumber < TotalPage); }
        }
       

    }
}
