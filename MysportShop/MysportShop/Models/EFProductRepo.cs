using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class EFProductRepo : IProductRepository
    {
        private ProductDbContext context;

        public EFProductRepo(ProductDbContext productDb)
        {
            context = productDb;

        }
        public void Save()
        {
            context.Products.Add(new MyProduct { NameProduct = "Board56", InfoWithProduct = "My favorite6", Price = 46785675, Categories = "Sport two" });
            context.SaveChanges();
        }
            
       public IQueryable<MyProduct> _Products => context.Products;
    }
}
