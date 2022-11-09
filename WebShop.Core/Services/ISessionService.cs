using WebShop.Core.Entities;

namespace WebShop.Core.Services;

public interface ISessionService
{
  int? GetOrderId();

  void SetOrderId(int id);

  int? GetInvoicedOrderId();

  void SetInvoicedOrderId(int id);

  (int? minAmount, int? maxAmount, ProductCategory? category) GetFilter();

  void SetFilter(ProductCategory category, int? minAmount = null, int? maxAmount = null);
}
