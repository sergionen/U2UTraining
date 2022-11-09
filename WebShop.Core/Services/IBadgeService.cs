using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;

namespace WebShop.Core.Services;

public interface IBadgeService
{
    (string, string) GetInfo(Product product);
}
