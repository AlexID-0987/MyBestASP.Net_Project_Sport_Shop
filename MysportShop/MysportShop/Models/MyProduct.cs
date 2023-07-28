using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class MyProduct
    {
        [Key]
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string InfoWithProduct { get; set; }
        public decimal Price { get; set; }
    }
}
//create model product