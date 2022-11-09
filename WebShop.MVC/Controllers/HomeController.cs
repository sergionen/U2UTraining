using Microsoft.AspNetCore.Mvc;
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

        private readonly IBadgeService _badge;

        public HomeController(ILogger<HomeController> logger, IProductRepository repository, ISessionService session, IBadgeService badge)
        {
            _logger = logger;
            this.repository = repository;
            this.session = session;
            this._badge = badge;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] ProductCategory category = ProductCategory.All)
        {
            session.SetFilter(category);
            var products = repository.WithFilter()
                                              .Select(p => new HomeIndexVM()
                                              {
                                                  Name = p.Name,
                                                  ImgUrl = p.ImgUrl,
                                                  Price = p.Price,
                                                  ProductCategory = p.ProductCategory,
                                                  Provider = p.Provider,
                                                  Score = p.GetReviewScore(),
                                                  Stars = p.GetStarsPercentage(),
                                                  Badge = _badge.GetInfo(p)
                                              });
            return View(model: products);
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