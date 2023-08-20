using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class ListPagination
    {
        public int TotalItems { get; set; }
        public int ItemaperPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage =>
            (int)Math.Ceiling((decimal)TotalItems / ItemaperPage);
    }
}
