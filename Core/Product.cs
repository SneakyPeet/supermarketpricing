namespace Core
{
    public class Product
    {
        public int ProductId { get; private set; }
        private readonly int cost;
        private readonly IPricingModel pricingModel;

        public Product(int productId, int cost, IPricingModel pricingModel)
        {
            this.ProductId = productId;
            this.cost = cost;
            this.pricingModel = pricingModel;
        }

        public int GetPrice(int quantity)
        {
            return pricingModel.CalculatePrice(cost,quantity);
        }
    }
}