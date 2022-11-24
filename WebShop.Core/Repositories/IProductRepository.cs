using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;

namespace WebShop.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetOnlyProducts();

        IEnumerable<Product> WithFilter();

        Product? GetProductWithId(int id);


    }
}
