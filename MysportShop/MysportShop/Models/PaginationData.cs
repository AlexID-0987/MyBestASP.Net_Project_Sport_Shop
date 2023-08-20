using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class PaginationData
    {
        public IEnumerable<MyProduct> myProducts { get; set; }
        public Pagination Pagination { get; set; }
    }
}
