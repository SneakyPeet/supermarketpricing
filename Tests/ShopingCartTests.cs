using System.Collections;
using System.Collections.Generic;
using Core;
using Core.PricingModels;
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
                yield return new TestCaseData(new List<Product>{MakeFreeItem("Naartjie", 100)}, 0, "FreeItem should cost nothing");
                yield return new TestCaseData(new List<Product> { MakeItem("Naartjie", 100) }, 100, "Single item should cost the same as product");
                yield return new TestCaseData(new List<Product> { MakeItem("Naartjie", 100), MakeItem("Apple", 200) }, 300, "Multiple items should cost the same as products combined");
                yield return new TestCaseData(new List<Product> { MakeItem("Naartjie", 100), MakeItem("Naartjie", 100) }, 200, "Multiple similar items should cost the same as products combined");
                yield return new TestCaseData(new List<Product> { Make3For150(), Make3For150(), Make3For150() }, 150, "Three For A Price Should Cost Price");
                yield return new TestCaseData(new List<Product> { Make3For150(), Make3For150() }, 200, "Three For A Price Should With One Item Should Cost Item Price");
                yield return new TestCaseData(new List<Product> { Make3For150(), Make3For150(), Make3For150(), Make3For150() }, 250, "multiple Quantity For Price Should be correct");
                yield return new TestCaseData(new List<Product> { Make3For150(), Make3For150(), Make3For150(), Make3For150(), Make3For150(), Make3For150() }, 300, "multiple Quantity For Price Should be correct");
                
                yield return new TestCaseData(new List<Product> { MakeBuy2OneFree() }, 100, "Buy Two Get One Free should return cost if only one is bought");
                yield return new TestCaseData(new List<Product> { MakeBuy2OneFree(), MakeBuy2OneFree() }, 200, "Buy Two Get One Free should return correct Price: 2|2");
                yield return new TestCaseData(new List<Product> { MakeBuy2OneFree(), MakeBuy2OneFree(), MakeBuy2OneFree() }, 200, "Buy Two Get One Free should return correct Price 3|2");
                yield return new TestCaseData(new List<Product> { MakeBuy2OneFree(), MakeBuy2OneFree(), MakeBuy2OneFree(), MakeBuy2OneFree() }, 300, "Buy Two Get One Free should return correct Price 4|3");
                yield return new TestCaseData(new List<Product> { MakeBuy2OneFree(), MakeBuy2OneFree(), MakeBuy2OneFree(), MakeBuy2OneFree(), MakeBuy2OneFree(), MakeBuy2OneFree(), MakeBuy2OneFree() }, 500, "Buy Two Get One Free should return correct Price 7|5");

                yield return new TestCaseData(new List<Product> { MakeBuy2TwoFree() }, 100, "Buy Two Get Two Free should return correct Price 1|1");
                yield return new TestCaseData(new List<Product> { MakeBuy2TwoFree(), MakeBuy2TwoFree() }, 200, "Buy Two Get Two Free should return correct Price 2|2");
                yield return new TestCaseData(new List<Product> { MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree() }, 200, "Buy Two Get Two Free should return correct Price 3|2");
                yield return new TestCaseData(new List<Product> { MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree() }, 200, "Buy Two Get Two Free should return correct Price 4|2");
                yield return new TestCaseData(new List<Product> { MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree() }, 300, "Buy Two Get Two Free should return correct Price 5|3");
                yield return new TestCaseData(new List<Product> { MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree(), MakeBuy2TwoFree() }, 400, "Buy Two Get Two Free should return correct Price 7|4");

                yield return new TestCaseData(new List<Product>
                                                  {
                                                      MakeFreeItem("Onions",100),
                                                      MakeItem("Naartjie", 200),
                                                      MakeItem("Naartjie", 200),//400
                                                      Make3For150(),
                                                      Make3For150(),
                                                      Make3For150(),
                                                      Make3For150(),//650
                                                      MakeBuy2OneFree(),
                                                      MakeBuy2OneFree(),
                                                      MakeBuy2OneFree(),//850
                                                      MakeBuy2TwoFree(),
                                                      MakeBuy2TwoFree(),
                                                      MakeBuy2TwoFree(),
                                                      MakeBuy2TwoFree(),
                                                      MakeBuy2TwoFree(),
                                                      MakeBuy2TwoFree(),
                                                      MakeBuy2TwoFree(),//1250
                                                  }, 1250, "Multiple Items");
            }
        }

        private static Product MakeItem(string name, int cost)
        {
            return new Product(name, cost, new PriceEqualsCostPricing());
        }

        private static Product MakeFreeItem(string name, int cost)
        {
            return new Product(name, cost, new FreePricing());
        }

        private static Product Make3For150()
        {
            return new Product("Apples", 100, new QuantityForPrice(3, 150));
        }

        private static Product MakeBuy2OneFree()
        {
            return new Product("Oranges", 100, new QuantityFreeForQuantityPricing(2,1));
        }

        private static Product MakeBuy2TwoFree()
        {
            return new Product("Potatos", 100, new QuantityFreeForQuantityPricing(2, 2));
        }
    }
}