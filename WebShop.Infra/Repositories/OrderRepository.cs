using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        

        //private readonly ISessionService session;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public OrderRepository(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

        //private HttpContext HttpContext
        //=> _httpContextAccessor.HttpContext!;

        //public OrderRepository(ISessionService session)
        //{
        //    this.session = session;
            
        //}

        IEnumerable<Order> IOrderRepository.WithFilter()
        {
            throw new NotImplementedException();
        }

        Order? IOrderRepository.GetOrderWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Order CreateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
