namespace Core.PricingModels
{
    internal class FreePricing : IPricingModel 
    {
        public int CalculatePrice(int cost, int quantity)
        {
            return 0;
        }
    }
}