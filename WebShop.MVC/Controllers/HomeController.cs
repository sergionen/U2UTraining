using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;
using WebShop.MVC.Models;
using WebShop.MVC.ViewModel.Home;

namespace WebShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductRepository repository;

        private readonly ISessionService session;

        private readonly IBadgeService badge;

        private readonly IOrderService orderService;

        private readonly IOrderRepository orderRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository repository, ISessionService session, IBadgeService badge, IOrderService service, IOrderRepository orderRepository)
        {
            _logger = logger;
            this.repository = repository;
            this.session = session;
            this.badge = badge;
            this.orderService = service;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ProductCategory category = ProductCategory.All, int? minAmount = null, int? maxAmount = null)
        {
            session.SetFilter(category, minAmount, maxAmount);

            var aux_products = repository.GetOnlyProducts();

            ViewBag.CountAllProducts = aux_products.Count();
            ViewBag.CountSnackProducts = aux_products.Count(p => p.ProductCategory == ProductCategory.Snack);
            ViewBag.CountMeatProducts = aux_products.Count(p => p.ProductCategory == ProductCategory.Meats);
            ViewBag.CountVegetableProducts = aux_products.Count(p => p.ProductCategory == ProductCategory.Vegetables);

            var products = repository.WithFilter()
                                              .Select(p => new HomeIndexVM()
                                              {
                                                  Name = p.Name,
                                                  ImgUrl = p.ImgUrl,
                                                  Price = Math.Round(p.Price,2),
                                                  ProductCategory = p.ProductCategory,
                                                  Provider = p.Provider,
                                                  Id = p.Id
                                                  Score = Math.Round(p.GetReviewScore(), 2),
                                                  Stars = Math.Round(p.GetStarsPercentage(), 2),
                                                  Badge = badge.GetInfo(p)
                                              });
            return View(model: products);
        }

        //[HttpPost]
        //public IActionResult ShoppingBasket()
        //{
        //    var order = orderService.GetCurrentOrder();
        //    return View(order);
        //}

        [HttpPost]
        public async Task<IActionResult> ShoppingBasket(int id)
        {
            orderService.AddProductToCurrentOrder(id);
            var order = orderService.GetCurrentOrder();
            Decimal price = 0;
            foreach (var item in order.Products)
            {
                price += item.Price; 
            }
            order.Total = price;
            await orderRepository.Save(order);
            return View(order);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}