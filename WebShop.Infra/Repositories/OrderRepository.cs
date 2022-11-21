using Microsoft.EntityFrameworkCore;
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
 
        private readonly WebShopDbContext _db;

        private readonly ISessionService session;

        public OrderRepository(ISessionService session, WebShopDbContext db)
        {
            this.session = session;
            this._db = db;
        }

        IEnumerable<Order> IOrderRepository.WithFilter()
        {
            throw new NotImplementedException();
        }

        Order? IOrderRepository.GetOrderWithId(int id)
        {
            return _db.Order.Include(o => o.Products).FirstOrDefault(p => p.Id == id);
        }

        public Order CreateOrder()
        {
            Order order = new Order();
            _db.Order.Add(order);
            _db.SaveChanges();
            return order;
        }

        public async Task Save(Order order)
        {
            await _db.SaveChangesAsync();
        }
    }
}
