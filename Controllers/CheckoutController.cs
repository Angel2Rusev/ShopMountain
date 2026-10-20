using Microsoft.AspNetCore.Mvc;
using PROJECT_ANGEL.Models;
using PROJECT_ANGEL.Services;

namespace PROJECT_ANGEL.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            var cartItems = CartService.GetCartItems();
            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            var order = new Order
            {
                Items = cartItems,
                TotalAmount = CartService.GetTotal()
            };

            return View(order);
        }

        [HttpPost]
        public IActionResult ProcessOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", order);
            }

            // In a real application, you would:
            // 1. Save the order to a database
            // 2. Process payment
            // 3. Send confirmation email
            // 4. Clear the cart

            // For this demo, we'll just clear the cart and show success
            CartService.ClearCart();
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
