﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MysportShop.Models;

namespace MysportShop
{
    public class Startup
    {
        public Startup(IConfiguration confguration) => Configuration = confguration;
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(
               Configuration["Data:SportStore:DefaultConnection"]));
            services.AddTransient<IProductRepository, EFProductRepo>();
            //services.AddDbContext<ProductDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddSession(options=> 
            {
                
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello My very best Padavan!");
            //});
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes => { 
            routes.MapRoute(
            name: "default",
            template: "{controller=Product}/{action=List}/{id?}");
            });
            //SeedData.EnsurePopulated(app);
            
            
        }
    }
}
