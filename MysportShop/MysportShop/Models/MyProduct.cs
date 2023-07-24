using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class MyProduct
    {
        public int ProdID { get; set; }
        public string NameProduct { get; set; }
        public string InfoWithProduct { get; set; }
        public decimal Price { get; set; }
    }
}
//create model product