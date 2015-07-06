namespace Core.PricingModels
{
    internal class FreePricing : IPricingModel 
    {
        public int CalculatePrice(int cost, int quantity)
        {
            return 0;
        }

        public string PricingInUnits(string token, int factor, int cost)
        {
            return token + 0.ToString("0.00");
        }

    }
}