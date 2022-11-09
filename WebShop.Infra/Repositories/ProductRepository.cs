using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebShopDbContext _db;

        private readonly ISessionService session;

        public ProductRepository(ISessionService session, WebShopDbContext db)
        {
            this.session = session;
            this._db = db;
        }

        public Product? GetProductWithId(int id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> WithFilter()
        {
            var products = _db.Products.ToList();
            var (minAmount, maxAmount, category) = session.GetFilter();

            if (minAmount is not null)
                products = products.Where(p => p.Price >= minAmount).ToList();
            if (maxAmount is not null)
                products = products.Where(p => p.Price <= maxAmount).ToList();
            if (category != ProductCategory.All)
                products = products.Where(p => p.ProductCategory == category).ToList();

            return products;
        }
    }
}
