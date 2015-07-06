using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class ShoppingCart
    {
        private readonly List<Product> cartItems;

        public ShoppingCart()
        {
            this.cartItems = new List<Product>();
        }
        public int Price
        {
            get
            {
                return cartItems.Sum(x => x.Price);
            }
        }

        public void AddItems(List<Product> items)
        {
            foreach(var item in items)
            {
                AddItem(item);
            }
        }

        private void AddItem(Product item)
        {
            cartItems.Add(item);
        }
    }
}
