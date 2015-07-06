namespace Core.PricingModels
{
    internal class QuantityForPrice : IPricingModel 
    {
        private readonly int quantityForPrice;
        private readonly int price;

        public QuantityForPrice(int quantityForPrice, int price)
        {
            this.quantityForPrice = quantityForPrice;
            this.price = price;
        }

        public int CalculatePrice(int cost, int quantity)
        {
            var totalMatchingQuantity = quantity/this.quantityForPrice;
            var totalNotMatchingQuantity = quantity % this.quantityForPrice;
            return (totalMatchingQuantity * this.price) + (totalNotMatchingQuantity * cost);
        }
    }
}