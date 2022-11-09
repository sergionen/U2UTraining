using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.MVC.Services
{
    public class OrderService: IOrderService
    {

        private readonly ISessionService _sessionService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(ISessionService? sessionService, IOrderRepository? repository)
        {
            _sessionService = sessionService;
            _orderRepository = repository;   
        }

        public Order GetCurrentOrder()
        {
            int? orderId = _sessionService.GetOrderId(); 
            Order? order = null;
            if (orderId.HasValue)
            {
                order = _orderRepository.GetOrderWithId(orderId.Value);
            }
            if (order is null)
            {
                order = _orderRepository.CreateOrder();
                _sessionService.SetOrderId(order.Id);
            }
            return order;
        }

        void IOrderService.AddProductToCurrentOrder(int productId)
        {
            throw new NotImplementedException();
        }

        Order? IOrderService.GetInvoicedOrder()
        {
            throw new NotImplementedException();
        }

        void IOrderService.RemoveProductFromCurrentOrder(int productId, bool all)
        {
            throw new NotImplementedException();
        }

        void IOrderService.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
