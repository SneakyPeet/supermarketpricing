using System.Collections;
using System.Collections.Generic;
using Core;
using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public class ShopingCartTests
    {
        [Test, TestCaseSource(typeof(ShopingCartTestCaseFactory),"TestCases")]
        public void ShoppingCartTests(List<Product> items, int expectedCost, string failMessage)
        {
            var cart = new ShoppingCart();
            cart.AddItems(items);
            Assert.AreEqual(expectedCost, cart.Price, failMessage);
        }
    }

    public class ShopingCartTestCaseFactory
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<Product>(), 0, "Empty cart should cost nothing");
                yield return new TestCaseData(new List<Product>{MakeFreeItem(1, 100)}, 0, "FreeItem should cost nothing");
                yield return new TestCaseData(new List<Product> { MakeItem(1, 100)}, 100, "Single item should cost the same as product");
                yield return new TestCaseData(new List<Product> { MakeItem(1, 100), MakeItem(2, 200) }, 300, "Multiple items should cost the same as products combined");
                yield return new TestCaseData(new List<Product> { MakeItem(1, 100), MakeItem(1, 100) }, 200, "Multiple similar items should cost the same as products combined");
                yield return new TestCaseData(new List<Product> { Make3ForPrice(), Make3ForPrice(), Make3ForPrice() }, 150, "Three For A Price Should Cost Price");
                yield return new TestCaseData(new List<Product> { Make3ForPrice(), Make3ForPrice() }, 200, "Three For A Price Should With One Item Should Cost Item Price");
                yield return new TestCaseData(new List<Product> { Make3ForPrice(), Make3ForPrice(), Make3ForPrice(), Make3ForPrice() }, 250, "multiple Quantity For Price Should be correct");
                yield return new TestCaseData(new List<Product> { Make3ForPrice(), Make3ForPrice(), Make3ForPrice(), Make3ForPrice(), Make3ForPrice(), Make3ForPrice() }, 300, "multiple Quantity For Price Should be correct");

            }
        }

        private static Product MakeItem(int productId, int cost)
        {
            return new Product(productId, cost, new PriceEqualsCostPricing());
        }

        private static Product MakeFreeItem(int productId, int cost)
        {
            return new Product(productId, cost, new FreePricing());
        }

        private static Product Make3ForPrice()
        {
            return new Product(1, 100, new QuantityForPrice(3, 150));
        }
    }
}