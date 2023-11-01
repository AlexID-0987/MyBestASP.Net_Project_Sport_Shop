using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class BuyOrderDataBase
    {
        public int Id { get; set;}
        public BuyProduct BuyProduct { get; set; }
    }
}
