using WebShop.Core.Entities;
using WebShop.Core.Services;

namespace WebShop.MVC.Services;

public class SessionService : ISessionService
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public SessionService(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

  private HttpContext HttpContext
  => _httpContextAccessor.HttpContext!;

  public int? GetOrderId()
  => HttpContext.Session.GetInt32(SessionKeys.Order);

  public int? GetInvoicedOrderId()
  => HttpContext.Session.GetInt32(SessionKeys.Invoice);

  public (int? minAmount, int? maxAmount, ProductCategory? category) GetFilter()
  {
    int? minAmount = HttpContext.Session.GetInt32(SessionKeys.MinAmount);
    if (minAmount.HasValue && minAmount == int.MinValue)
    {
      minAmount = null;
    }
    int? maxAmount = HttpContext.Session.GetInt32(SessionKeys.MaxAmount);
    if (maxAmount.HasValue && maxAmount == int.MaxValue)
    {
      maxAmount = null;
    }
    int? cat = HttpContext.Session.GetInt32(SessionKeys.Category);
    ProductCategory category = cat.HasValue ? (ProductCategory)cat.Value : ProductCategory.All;
    return (minAmount, maxAmount, category);
  }

  public void SetFilter(ProductCategory category, int? minAmount = null, int? maxAmount = null)
  {
    HttpContext.Session.SetInt32(SessionKeys.MinAmount, minAmount ?? int.MinValue);
    HttpContext.Session.SetInt32(SessionKeys.MaxAmount, maxAmount ?? int.MaxValue);
    HttpContext.Session.SetInt32(SessionKeys.Category, (int)category);
  }

  public void SetOrderId(int id) 
  => HttpContext.Session.SetInt32(SessionKeys.Order, id);

  public void SetInvoicedOrderId(int id) 
  => HttpContext.Session.SetInt32(SessionKeys.Invoice, id);

}
