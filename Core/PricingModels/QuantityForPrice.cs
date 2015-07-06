namespace Core
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
            var totalMatchingQuantity = quantity/quantityForPrice;
            var totalNotMatchingQuantity = quantity % quantityForPrice;
            return (totalMatchingQuantity * price) + (totalNotMatchingQuantity * cost);
        }
    }
}