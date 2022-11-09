using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entities
{
    public class Order
    {
        public IEnumerable<Product>? Cart { get; set; }

        public Order()
        {

        }
    }
}
