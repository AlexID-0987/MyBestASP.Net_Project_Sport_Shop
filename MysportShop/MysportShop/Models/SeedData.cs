using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ProductDbContext context = app.ApplicationServices.GetRequiredService<ProductDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new MyProduct
                {
                    Id=1,
                    NameProduct="Board",
                    InfoWithProduct="Sea",
                    Price=543
                },
                new MyProduct
                {
                    Id=2,
                    NameProduct = "tree",
                    InfoWithProduct = "Forest",
                    Price = 1543
                });
                context.SaveChanges();
            }
        }

    }
}
