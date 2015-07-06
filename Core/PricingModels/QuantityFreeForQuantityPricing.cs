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
            var itemsToCalculate = quantity;
            var price = 0;
            while(itemsToCalculate > 0)
            {
                if(itemsToCalculate <= quantityToBuy)
                {
                    price += itemsToCalculate * cost;
                    itemsToCalculate = 0;
                }
                else
                {
                    price += quantityToBuy * cost;
                    itemsToCalculate -= quantityToBuy;
                    if(itemsToCalculate > quantityFree)
                    {
                        itemsToCalculate -= quantityFree;
                    }
                    else
                    {
                        itemsToCalculate = 0;
                    }
                }
            }
            return price;
            //var totalWithDiscount = quantity / TotalWithDiscount();
            //var totalWithoutDiscount = quantity % TotalWithDiscount();
            //return (totalWithDiscount * quantityToBuy * cost) + (totalWithoutDiscount*cost);
        }

        private int TotalWithDiscount()
        {
            return quantityToBuy + quantityFree;
        }
    }
}