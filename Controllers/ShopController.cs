using Microsoft.AspNetCore.Mvc;
using PROJECT_ANGEL.Models;

namespace PROJECT_ANGEL.Controllers
{
    public class ShopController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Mountain Climbing Helmet", Description = "Professional climbing helmet with ventilation", Price = 89.99m, Category = "Climbing", ImageUrl = "/images/helmet.jpg", Stock = 15 },
            new Product { Id = 2, Name = "Hiking Backpack 65L", Description = "Durable backpack for multi-day hikes", Price = 149.99m, Category = "Hiking", ImageUrl = "/images/backpack.jpg", Stock = 20 },
            new Product { Id = 3, Name = "Climbing Rope 60m", Description = "Dynamic climbing rope, certified", Price = 199.99m, Category = "Climbing", ImageUrl = "/images/rope.jpg", Stock = 10 },
            new Product { Id = 4, Name = "Trekking Poles", Description = "Lightweight aluminum trekking poles", Price = 59.99m, Category = "Hiking", ImageUrl = "/images/poles.jpg", Stock = 25 },
            new Product { Id = 5, Name = "Climbing Harness", Description = "Comfortable adjustable harness", Price = 129.99m, Category = "Climbing", ImageUrl = "/images/harness.jpg", Stock = 12 },
            new Product { Id = 6, Name = "Mountaineering Boots", Description = "Waterproof boots for high altitude", Price = 249.99m, Category = "Footwear", ImageUrl = "/images/boots.jpg", Stock = 8 },
            new Product { Id = 7, Name = "Camping Tent 2-Person", Description = "Lightweight tent for alpine camping", Price = 299.99m, Category = "Camping", ImageUrl = "/images/tent.jpg", Stock = 5 },
            new Product { Id = 8, Name = "Sleeping Bag -10°C", Description = "Warm sleeping bag for cold conditions", Price = 179.99m, Category = "Camping", ImageUrl = "/images/sleepingbag.jpg", Stock = 15 },
            new Product { Id = 9, Name = "Headlamp", Description = "LED headlamp with 500 lumens", Price = 49.99m, Category = "Lighting", ImageUrl = "/images/headlamp.jpg", Stock = 30 },
            new Product { Id = 10, Name = "Climbing Chalk Bag", Description = "Professional chalk bag with brush", Price = 19.99m, Category = "Climbing", ImageUrl = "/images/chalkbag.jpg", Stock = 40 },
            new Product { Id = 11, Name = "Crampons", Description = "Steel crampons for ice climbing", Price = 159.99m, Category = "Climbing", ImageUrl = "/images/crampons.jpg", Stock = 10 },
            new Product { Id = 12, Name = "Portable Stove", Description = "Gas stove for outdoor cooking", Price = 79.99m, Category = "Camping", ImageUrl = "/images/stove.jpg", Stock = 20 }
        };

        public IActionResult Index(string? category, string? search)
        {
            var products = _products.AsEnumerable();

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => 
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.Categories = _products.Select(p => p.Category).Distinct().ToList();
            ViewBag.SelectedCategory = category;
            ViewBag.SearchTerm = search;

            return View(products.ToList());
        }

        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
