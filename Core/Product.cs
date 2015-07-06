namespace Core
{
    public class Product
    {
        private readonly int productId;
        private readonly int cost;

        public Product(int productId, int cost)
        {
            this.productId = productId;
            this.cost = cost;
        }

        public int Price
        {
            get
            {
                return cost;
            }
        }
    }
}