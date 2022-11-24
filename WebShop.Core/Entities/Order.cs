using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entities
{
    public class Order
    {
        public IList<Product> Products { get; set; } = new List<Product>();
        public Decimal Total { get; set; } 
        public int Id { get; private set; }

    }
}
