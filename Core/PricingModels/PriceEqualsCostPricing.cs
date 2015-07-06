namespace Core
{
    internal class PriceEqualsCostPricing : IPricingModel
    {
        public int CalculatePrice(int cost, int quantity)
        {
            return cost * quantity;
        }
    }
}