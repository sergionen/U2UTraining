using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entities
{
    public class Order: EntityBase
    {
        public IEnumerable<Product>? Products { get; set; }
        public Decimal ? Total { get; set; }    

        public Order(int id) : base(id)
        {
        }
    }
}
