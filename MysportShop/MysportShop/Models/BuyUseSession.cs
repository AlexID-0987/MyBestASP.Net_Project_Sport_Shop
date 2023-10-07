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
        public void AddItemMyProduct(int id, string nameProduct,string infoproduct, decimal price, string categories, int quantity, decimal summa)
        {
            
            buyProductsList.Add(new BuyProduct()
            {
                Id = id,
                NameProduct=nameProduct,
                InfoWithProduct=infoproduct,
                Price=price,
                Categories=categories,
                Quantity=quantity,
                
            });
        }
        public IEnumerable<BuyProduct> BuyProducts => buyProductsList;
    }
}
