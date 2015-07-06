namespace Core.PricingModels
{
    internal class QuantityFreeForQuantityPricing : IPricingModel
    {
        private readonly int quantityToBuy;
        private readonly int quantityFree;

        public QuantityFreeForQuantityPricing(int quantityToBuy, int quantityFree)
        {
            this.quantityToBuy = quantityToBuy;
            this.quantityFree = quantityFree;
        }

        public int CalculatePrice(int cost, int quantity)
        {
            var totalWithDiscount = quantity / TotalWithDiscount();
            var totalWithoutDiscount = quantity % TotalWithDiscount();
            return (totalWithDiscount * quantityToBuy * cost) + (totalWithoutDiscount*cost);
        }

        private int TotalWithDiscount()
        {
            return quantityToBuy + quantityFree;
        }
    }
}