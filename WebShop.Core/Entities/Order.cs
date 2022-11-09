using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entities
{
    internal class Order
    {
        public IEnumerable<Product>? Cart { get; set; }
        public Decimal  Total { get; set; } = Decimal.Zero;

        public Order()
        {

        }
    }
}
