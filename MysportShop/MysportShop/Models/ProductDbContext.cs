using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class ProductDbContext:DbContext
    {
        
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { Database.EnsureCreated(); }
        public DbSet<MyProduct> Products { get; set; }
        public DbSet<MyOrder> myOrders { get; set; }


    }
}
