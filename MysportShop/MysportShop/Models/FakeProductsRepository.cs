using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class FakeProductsRepository : IProductRepository
    {
        public IQueryable<MyProduct> _Products => new List<MyProduct>
        {
            new MyProduct{NameProduct="Shase",Price=3457},
            new MyProduct{NameProduct="Tea",Price=347},
        }.AsQueryable<MyProduct>();
    }
}
//Fake class with work while not data base