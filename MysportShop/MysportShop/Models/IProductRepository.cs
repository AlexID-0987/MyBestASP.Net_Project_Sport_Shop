using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public interface IProductRepository
    {
        IQueryable<MyProduct> _Products { get; }
        IQueryable<MyOrder> _myOrders { get; }
        void Save();
        void OrderSave(MyOrder myOrder);
        

        
    }
}
//інтерфейс працюючій з базой данних, схожий на IEnumerable<>