using Core;
using Core.PricingModels;
using NUnit.Framework;
using SharpTestsEx;

namespace Tests
{
    [TestFixture]
    public class PricingUnitsTests
    {
        [Test]
        public void Free()
        {
            var product = new Product("Gum", 100, new FreePricing());
            var priceInRandValue = product.PriceInRands();
            priceInRandValue.Should().Be.EqualTo("R0.00");
        }

        [Test]
        [TestCase(10, "R0.10")]
        [TestCase(100, "R1.00")]
        [TestCase(1010, "R10.10")]
        public void PriceForCost(int cost, string expected)
        {
            var product = new Product("Gum", cost, new PriceEqualsCostPricing());
            var priceInRandValue = product.PriceInRands();
            priceInRandValue.Should().Be.EqualTo(expected);
        }

        [Test]
        public void BuyOneGetOneFree()
        {
            var product = new Product("Gum", 1000, new QuantityFreeForQuantityPricing(2,1));
            var priceInRandValue = product.PriceInRands();
            priceInRandValue.Should().Be.EqualTo("R10.00 - Buy 3 For R20.00");
        }
    }
}