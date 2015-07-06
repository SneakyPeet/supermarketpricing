namespace Core.PricingModels
{
    internal class PriceEqualsCostPricing : IPricingModel
    {
        public int CalculatePrice(int cost, int quantity)
        {
            return cost * quantity;
        }

        public string PricingInUnits(string token, int factor, int cost)
        {
            return token + ((decimal)cost / factor).ToString("0.00");
        }
    }
}