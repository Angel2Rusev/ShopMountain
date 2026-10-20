using Microsoft.AspNetCore.Mvc;
using PROJECT_ANGEL.Models;
using PROJECT_ANGEL.Services;

namespace PROJECT_ANGEL.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View(CartService.GetCartItems());
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, string productName, decimal price, string imageUrl, int quantity = 1)
        {
            CartService.AddToCart(productId, productName, price, imageUrl, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            CartService.UpdateQuantity(productId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            CartService.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            CartService.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
