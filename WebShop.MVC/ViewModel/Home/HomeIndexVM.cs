using WebShop.Core.Entities;

namespace WebShop.MVC.ViewModel.Home
{
    public class HomeIndexVM
    {
        public string Name { get; set; } = default!;

        public decimal Price { get; set; }

        public string Provider { get; set; } = default!;

        public string ImgUrl { get; set; } = default!;

        public ProductCategory ProductCategory { get; set; }

        public decimal Score { get; set; }

        public string? Badge { get; set; }

        public double Stars { get; set; }
    }
}
