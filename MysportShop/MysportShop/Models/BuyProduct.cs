using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class BuyProduct:MyProduct
    {
        
        public int Quantity { get; set; } = 1;
        public decimal SummaOnsetProduct { get; set; }
        public MyProduct MyProduct { get; set; }
        public decimal QuantityToPrice(decimal price, int quantity)
        {
            return price * quantity;
        }
        
        
    }
}
