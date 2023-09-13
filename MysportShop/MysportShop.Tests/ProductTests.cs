using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MysportShop.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChance()
        {
            var a = new MysportShop.Models.MyProduct { NameProduct = "Trip", Price = 45 };
            a.NameProduct = "yes";
            Assert.Equal("yes", a.NameProduct);
        }
    }
}
