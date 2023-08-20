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


        public int PageSize = 4;
        

        public ProductController(IProductRepository myrepo)
        {
            product = myrepo;
        }
        /*
        public ViewResult List(int productPage = 1) => View(new ProductListViewModel
        {
            
            myProducts = product._Products.OrderBy(p => p.Id).Skip((productPage - 1) * PageSize).Take(PageSize),
            ListPagination = new ListPagination
            {
                CurrentPage=productPage,
                ItemaperPage=PageSize,
                TotalItems=product._Products.Count()
            }
            
            
        });
        */
        
        public async Task <IActionResult> List(int page = 1)
        {

            var item1 = product._Products.ToList();
            var count = item1.Count();
            int size = 2;
            var pag1 = item1.Skip((page - 1) * size).Take(size).ToList();
            Pagination pagination1 = new Pagination(count, page, size);
            PaginationData paginationData = new PaginationData
            {
                Pagination= pagination1,
                myProducts = pag1
            };
            ViewBag.Count = count;
            ViewBag.Page1 = pagination1;
            ViewBag.PageNumber = page;
            return View(pag1);
        }
        
        public async Task <IActionResult> Index(int page=1)
        {
            var item = product._Products.ToList();
            var count = item.Count();
            int pagesize = 3;
            var pag = item.Skip((page - 1) * pagesize).Take(pagesize).ToList();
            Pagination pagination = new Pagination(count, page, pagesize);
            PaginationData paginationData = new PaginationData
            {
                Pagination = pagination,
                myProducts = pag
            };
            ViewBag.Count = count;
            ViewBag.Page = pagination;
            ViewBag.PageNumber = page;
            return View(pag);
        }
    }
}