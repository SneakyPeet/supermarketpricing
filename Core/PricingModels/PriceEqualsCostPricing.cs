namespace Core.PricingModels
{
    internal class PriceEqualsCostPricing : IPricingModel
    {
        public int CalculatePrice(int cost, int quantity)
        {
            return cost * quantity;
        }
    }
}