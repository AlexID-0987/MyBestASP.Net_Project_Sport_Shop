using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class MyOrder
    {
        public int MyOrderId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int ProductId { get; set; }
    }
}
