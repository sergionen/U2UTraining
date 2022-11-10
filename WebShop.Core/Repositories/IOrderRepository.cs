using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;

namespace WebShop.Core.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> WithFilter();
        Order? GetOrderWithId(int id);
        Order CreateOrder();
        Task Save(Order order);
    }
}
