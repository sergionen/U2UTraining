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

        async Task IOrderService.AddProductToCurrentOrder(int productId)
        {
            if (productId < 0)
                throw new ArgumentOutOfRangeException("Product Id cannot be negative numnber.");
            
            var order = GetCurrentOrder();
            var product = _productRepository.GetProductWithId(productId);
            if (order is not null && product is not null)
            {
                order.Products.Add(product);
                await _orderRepository.Save(order);
            }
            else
                throw new NullReferenceException("Product not found.");
        }

        Order? IOrderService.GetInvoicedOrder()
        {
            throw new NotImplementedException();
        }

        async Task<bool> IOrderService.RemoveProductFromCurrentOrder(int productId, bool all = false)
        {
            if (productId < 0)
                throw new ArgumentOutOfRangeException("Product Id cannot be negative numnber.");
            
            var order = GetCurrentOrder();

            if (all)
            {
                order.Products.Clear();
                await _orderRepository.Save(order);
                return true;
            }
            else
            {
                var product = _productRepository.GetProductWithId(productId);
                if (product is not null && order is not null)
                {
                    if (order.Products.Remove(product))
                    {
                        await _orderRepository.Save(order);
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
    }
}
