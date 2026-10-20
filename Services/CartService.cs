using PROJECT_ANGEL.Models;

namespace PROJECT_ANGEL.Services
{
    public static class CartService
    {
        private static List<CartItem> _cart = new List<CartItem>();

        public static List<CartItem> GetCartItems()
        {
            return _cart;
        }

        public static void AddToCart(int productId, string productName, decimal price, string imageUrl, int quantity = 1)
        {
            var existingItem = _cart.FirstOrDefault(c => c.ProductId == productId);
            
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity,
                    ImageUrl = imageUrl
                });
            }
        }

        public static void UpdateQuantity(int productId, int quantity)
        {
            var item = _cart.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    _cart.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
            }
        }

        public static void RemoveFromCart(int productId)
        {
            var item = _cart.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                _cart.Remove(item);
            }
        }

        public static void ClearCart()
        {
            _cart.Clear();
        }

        public static decimal GetTotal()
        {
            return _cart.Sum(item => item.Price * item.Quantity);
        }

        public static int GetItemCount()
        {
            return _cart.Sum(item => item.Quantity);
        }
    }
}
