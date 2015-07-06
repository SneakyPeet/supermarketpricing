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

        public int Id
        {
            get
            {
                return this.product.ProductId;
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