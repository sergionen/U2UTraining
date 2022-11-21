using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;

namespace WebShop.Core.Services
{

    public interface IOrderService
    {
        Order GetCurrentOrder();
        Order? GetInvoicedOrder();
        void AddProductToCurrentOrder(int productId);
        void RemoveProductFromCurrentOrder(int productId, bool all = false);
        void SaveChanges();
    }
}
