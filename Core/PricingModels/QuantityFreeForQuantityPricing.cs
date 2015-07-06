using System;

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
        }

        public string PricingInUnits(string token, int factor, int cost)
        {
            return string.Format("{0} - Buy {1} For {2}", this.GetPricingInUnit(token, factor, cost), (this.quantityToBuy + this.quantityFree), this.GetPricingInUnit(token, factor, this.quantityToBuy * cost));
        }

        private string GetPricingInUnit(string token, int factor, int cost)
        {
            return token + ((decimal)cost / factor).ToString("0.00");
        }

        
    }
}