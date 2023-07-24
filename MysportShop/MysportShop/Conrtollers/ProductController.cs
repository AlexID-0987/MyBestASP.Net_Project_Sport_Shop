using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MysportShop.Models;

namespace MysportShop.Conrtollers
{
    public class ProductController : Controller
    {
        private IProductRepository product;
        public ProductController(IProductRepository myrepo)
        {
            product = myrepo;
        }
        public ViewResult List() => View(product._Products);
    }
}