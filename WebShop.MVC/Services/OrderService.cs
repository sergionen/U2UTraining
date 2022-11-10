using Microsoft.EntityFrameworkCore.Query.Internal;
using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.MVC.Services
{
    public class OrderService: IOrderService
    {

        private readonly ISessionService _sessionService;
        private readonly IOrderRepository _orderRepository;
        
        private readonly IProductRepository _productRepository;

        public OrderService(ISessionService? sessionService, IOrderRepository? orderRepository,  IProductRepository productRepository)
        {
            _sessionService = sessionService;
            _orderRepository = orderRepository;
            
            _productRepository = productRepository;
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
            var order = GetCurrentOrder();
            var product = _productRepository.GetProductWithId(productId);
            order.Products.Add(product);
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
