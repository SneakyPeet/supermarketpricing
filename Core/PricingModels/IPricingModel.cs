namespace Core.PricingModels
{
    public interface IPricingModel
    {
        int CalculatePrice(int cost, int quantity);

        string PricingInUnits(string token, int factor, int cost);
    }
}