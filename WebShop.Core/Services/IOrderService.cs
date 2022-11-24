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
        Task AddProductToCurrentOrder(int productId);
        Task<bool> RemoveProductFromCurrentOrder(int productId, bool all = false);
    }
}
