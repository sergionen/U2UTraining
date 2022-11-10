using WebShop.Core.Entities;
using WebShop.Core.Services;

namespace WebShop.MVC.Services
{
    public class BadgeService : IBadgeService
    {
        public (string, string) GetInfo(Product product)
        {
            (string, string) badge = ("", "");

            if ((DateTime.Now - product.CreationDate).Days < 30)
            {
                badge = ("New", "new");
            }

            if (product.GetReviewScore() >= 4)
            {
                badge = ("Hot", "sale");
            }

            if (product.Discount != 0)
            {
                badge = ($"{product.Discount}%", "best");
            }

            return badge;
        }
    }
}