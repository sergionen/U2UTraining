using Microsoft.AspNetCore.Mvc;
using MyWebShop.Models;
using System.Diagnostics;

namespace MyWebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowProduct(ProductTypes? id)
        {
            Product? product = null;
            if (id.Equals(ProductTypes.Food))
                product = new Food() { Name = "Pasta", UnitPrice = 3, Weight = 34.3M };
            else if (id.Equals(ProductTypes.Car))
                product = new Car() { Name = "Mazda", Speed = 3.4M, UnitPrice = 32 };
            else if (id.Equals(ProductTypes.Drink))
                product = new Drink() { Name = "Rum with Coke", ContainsAlcohol = true, UnitPrice = 6.02M };

            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}