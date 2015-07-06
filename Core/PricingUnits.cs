namespace Core
{
    public static class PricingUnits
    {
        public static string PriceInRands(this Product product)
        {
            return product.PricingInUnit("R", 100);
        }
    }
}