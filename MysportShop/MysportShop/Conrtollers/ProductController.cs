using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MysportShop.Models;
using Newtonsoft.Json;

namespace MysportShop.Conrtollers
{
    public class ProductController : Controller
    {
        private IProductRepository product;
        private IBuyRepository _buyRepository;
        

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
        [HttpPost]
        public IActionResult Order(int id)
        {
            
            var form = Request.Form;
            string na = form["name"];
            string Id = form["id"];
            int id1 = Convert.ToInt32(Id);
            string info = form["info"];
            string price = form["price"];
            double price1 = Convert.ToDouble(price);
            string categories = form["categories"];
            string quantityStr = form["quantity"];
            int quantity = Convert.ToInt32(quantityStr);
            int i = id;
            List<BuyProduct> buyProducts = new List<BuyProduct>()
            {
                new BuyProduct(){Id=id,NameProduct=na,InfoWithProduct=info,}
            };
            List<BuyProduct> newMySesion = new List<BuyProduct>();
            BuyProduct buy = new BuyProduct();
            double quant = buy.QuantityToPrice(price1,quantity);
            ViewBag.name = i;
            ViewBag.na = na;
            ViewBag.Id = Id;
            ViewBag.info = info;
            ViewBag.price = price;
            ViewBag.categories = categories;
            ViewBag.quantity = quantity;
            ViewBag.func = quant;
            HttpContext.Session.SetString("My","This is sesion");
            ViewBag.ses = HttpContext.Session.GetString("My");
            HttpContext.Session.SetString("My", $"{info}");
            ViewBag.ses1 = HttpContext.Session.GetString("My");
            HttpContext.Session.SetString("MyList", JsonConvert.SerializeObject(buyProducts));
            newMySesion = JsonConvert.DeserializeObject<List<BuyProduct>>(HttpContext.Session.GetString("MyList"));
            
            return View(newMySesion); 
        }
    }
}