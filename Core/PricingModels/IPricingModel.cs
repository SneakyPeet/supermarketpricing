namespace Core.PricingModels
{
    public interface IPricingModel
    {
        int CalculatePrice(int cost, int quantity);
    }
}