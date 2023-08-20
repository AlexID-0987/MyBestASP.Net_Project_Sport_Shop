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
                   
                    NameProduct="Board",
                    InfoWithProduct="Seajggkg",
                    Price=543
                },
                new MyProduct
                {
                    
                    NameProduct = "tree",
                    InfoWithProduct = "Forest",
                    Price = 1543
                },
                new MyProduct
                {

                    NameProduct = "tree",
                    InfoWithProduct = "Forestkjlk",
                    Price = 1543
                },
                new MyProduct
                {

                    NameProduct = "treejhgg",
                    InfoWithProduct = "Forest",
                    Price = 561543
                },
                new MyProduct
                {

                    NameProduct = "tree9",
                    InfoWithProduct = "Forest",
                    Price = 189543
                },
                new MyProduct
                {

                    NameProduct = "treaaaaaascg",
                    InfoWithProduct = "Forest",
                    Price = 561543
                },
                new MyProduct
                {

                    NameProduct = "tree9",
                    InfoWithProduct = "Forest",
                    Price = 18932543
                });
                context.SaveChanges();
            }
        }

    }
}
