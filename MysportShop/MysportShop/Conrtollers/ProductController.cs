using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MysportShop.Models;

using Newtonsoft.Json;

namespace MysportShop.Conrtollers
{
    public class ProductController : Controller
    {
        private IProductRepository product;
        private IBuyRepository buyRepository;
        public BuyUseSession BuyUseSession;
        
        
        
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
        
        public async Task <IActionResult> List(string category,int page = 1)
        {

            var item1 = product._Products.ToList();
            var count = item1.Count();
            Mycategories s = new Mycategories();
            
            int size = 2;
            var pag1 = item1.Where(p=>category==null||p.Categories==category).Skip((page - 1) * size).Take(size).ToList();
            Pagination pagination1 = new Pagination(count, page, size);
            PaginationData paginationData = new PaginationData
            {
                Pagination= pagination1,
                myProducts = pag1
            };

            
            ViewBag.Count = count;
            ViewBag.Page1 = pagination1;
            ViewBag.PageNumber = page;
            ViewBag.Cat = category;
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
        [HttpPost]
        public IActionResult ChoiceProduct()
        {
            var form = Request.Form;
            var item = form["sel"];
            ViewBag.My = item;
            int pageSize = 3;
            var item1 = product._Products.ToList();
            var pag1 = item1.Where(p => p.Categories == item);
            var countCategory = pag1.Count();
            ViewBag.Count = countCategory;
            return View(pag1);
        }
       
        public IActionResult Buy(int id, MyProduct my)
        {
            BuyProduct buyProduct = new BuyProduct();
            var productItem = product._Products.ToList();
            var oneproduct = productItem.Where(i => i.Id == id);
            int myId = id;
            var count=oneproduct.Count();
            int quantity = buyProduct.Quantity;
            ViewBag.count = count;
            ViewBag.ID = myId;
            ViewBag.Quantity = quantity;
            return View(oneproduct);
        }
        public decimal summa;
        
        [HttpPost]
        public IActionResult Order(int id, BuyProduct buyProduct)
        {

            int quantity = Convert.ToInt32(buyProduct.Quantity);
            decimal price = Convert.ToDecimal(buyProduct.Price);
            BuyProduct buyProduct1 = new BuyProduct();
            decimal summaProduct = buyProduct1.QuantityToPrice(price, quantity);
             

            var cart = GetCart();
            cart.AddItemMyProduct(buyProduct.Id, buyProduct.NameProduct, buyProduct.InfoWithProduct, buyProduct.Price, buyProduct.Categories, quantity, summaProduct);
            HttpContext.Session.SetJson("Cart", cart);


            
            //return View(mylist); 
            return Redirect("List");
            
        }
        
        public IActionResult MySessionList()
        {
            
            var cart = GetCart();
            
            return View(new CartIndexViewModel
            {
                BuyUseSession=cart
            });

        }
        public IActionResult RemoveElement(int id)
        {
            
            var cart = GetCart();
            cart.Removecart(id);
            HttpContext.Session.SetJson("Cart", cart);
            return View();
        }
        public IActionResult OrderProduct()
        {
            var item = GetCart();
            var it = item.BuyProducts.ToList();
            ViewBag.c = it;
            
            return View();
        }
        
            
        [HttpPost]
        public IActionResult OrderProduct(MyOrder order)
        {
            
            
                
                product.SaveOrderTable(order);
            
            

            return Redirect ("List");

        }
         

        private BuyUseSession GetCart()
        {
            BuyUseSession buyUseSession = HttpContext.Session.GetJson<BuyUseSession>("Cart");
            if (buyUseSession == null)
            {
                buyUseSession = new BuyUseSession();
                HttpContext.Session.SetJson("Cart", buyUseSession);
            }
            return buyUseSession;
        }

    }
}