using WebShop.Core.Entities;
using WebShop.Core.Services;

namespace WebShop.MVC.Services
{
    public class BadgeService : IBadgeService
    {
        public string GetText(Product product)
        {
            if (product.ProductCategory == ProductCategory.Meats)
                return "Hot";
            else
                return "New";
        }
    }
}
