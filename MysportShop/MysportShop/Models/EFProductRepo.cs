﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class EFProductRepo:IProductRepository
    {
        private ProductDbContext context;
        public EFProductRepo(ProductDbContext productDb)
        {
            context = productDb;
        }
        public IQueryable<MyProduct> _Products => context.Products;
    }
}