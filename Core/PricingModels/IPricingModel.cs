namespace Core
{
    public interface IPricingModel
    {
        int CalculatePrice(int cost, int quantity);
    }
}