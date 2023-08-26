using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<MyProduct> myProducts { get; set; }
        public ListPagination ListPagination { get; set; }
        public string CurrentCategory { get; set; }
    }
}
