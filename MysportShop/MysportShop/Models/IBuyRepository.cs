using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public interface IBuyRepository
    {
        IQueryable<BuyProduct> _buyProducts { get; }
    }
}
