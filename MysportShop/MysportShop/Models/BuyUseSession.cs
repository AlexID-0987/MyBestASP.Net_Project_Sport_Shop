using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public class BuyUseSession
    {
        private List<BuyProduct> buyProductsList = new List<BuyProduct>();
        BuyProduct BuyProduct = new BuyProduct();
        public void AddItemMyProduct(int id, string nameProduct, string infoproduct, decimal price, string categories, int quantity, decimal summa)
        {
            
            BuyProduct buy = buyProductsList.Where(a =>a.Id == id).FirstOrDefault();
            if (buy == null)
            {
                buyProductsList.Add(new BuyProduct()
                {
                    Id=id,
                    NameProduct=nameProduct,
                    InfoWithProduct=infoproduct,
                    Price=price,
                    Categories=categories,
                    Quantity = quantity,
                    SummaOnsetProduct = BuyProduct.QuantityToPrice(price, quantity)

                });
            }
            else
            {
                buy.Quantity += quantity;
                buy.SummaOnsetProduct += price;

            }
        }


            public void Removecart(int id)
        {
            
            
            buyProductsList.RemoveAll(a=>a.Id==id);
        }

        public decimal TotalValue() =>
            buyProductsList.Sum(e => e.Price * e.Quantity);
        


        public virtual IEnumerable<BuyProduct> BuyProducts => buyProductsList;
    }
}
