using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class FakeProductsRepository 
    {
        public IQueryable<MyProduct> _Products => new List<MyProduct>
        {
            new MyProduct{Id=1,NameProduct="Shase",InfoWithProduct="Hand", Price=3457},
            new MyProduct{Id=2, NameProduct="Tea",InfoWithProduct="Eat", Price=347},
            new MyProduct{Id=3,NameProduct="Shase",InfoWithProduct="Hand", Price=3457},
            new MyProduct{Id=4, NameProduct="Tea",InfoWithProduct="Eat", Price=347},
        }.AsQueryable<MyProduct>();
    }
}
//Fake class with work while not data base