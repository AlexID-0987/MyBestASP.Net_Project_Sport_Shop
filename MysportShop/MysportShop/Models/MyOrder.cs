using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class MyOrder
    {
        [BindNever]
        public int MyOrderId { get; set; }
        [BindNever]
        public ICollection<BuyProduct> Buys { get; set; }
        [Required(ErrorMessage ="Please enter you name!")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Please enter you phone!")]
        public string Phone { get; set; }
        
        
    }
}
