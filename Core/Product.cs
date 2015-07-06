using Core.PricingModels;

namespace Core
{
    public class Product
    {
        public string Name { get; private set; }
        private readonly int cost;
        private readonly IPricingModel pricingModel;

        public Product(string name, int cost, IPricingModel pricingModel)
        {
            this.Name = name;
            this.cost = cost;
            this.pricingModel = pricingModel;
        }

        public int GetPrice(int quantity)
        {
            return pricingModel.CalculatePrice(cost, quantity);
        }

        public string PricingInUnit(string token, int factor)
        {
            return pricingModel.PricingInUnits(token, factor, cost);
        }
    }
}