using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entities
{
    public class EntityBase
    {
        public int Id { get; private set; }

        public EntityBase(int id) => Id = id;
    }
}
