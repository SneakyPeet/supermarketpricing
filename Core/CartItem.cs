namespace Core
{
    class CartItem
    {
        private readonly Product product;
        private int total;

        public CartItem(Product product)
        {
            this.product = product;
            this.total = 1;
        }

        public string Name
        {
            get
            {
                return this.product.Name;
            }
        }

        public void AddItem()
        {
            this.total++;
        }

        public int GetPrice
        {
            get
            {
                return product.GetPrice(total);
            }
        }

    }
}