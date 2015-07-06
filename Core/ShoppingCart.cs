using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class ShoppingCart
    {
        private readonly List<CartItem> cartItems;

        public ShoppingCart()
        {
            this.cartItems = new List<CartItem>();
        }
        public int Price
        {
            get
            {
                return cartItems.Sum(x => x.GetPrice);
            }
        }

        public void AddItems(List<Product> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        private void AddItem(Product item)
        {
            var cartItem = cartItems.SingleOrDefault(x => x.Name == item.Name);
            if(cartItem != null)
            {
                cartItem.AddItem();
            }
            else
            {
                cartItems.Add(new CartItem(item));
            }
        }
    }
}
