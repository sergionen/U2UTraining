using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entities
{
    public class ReviewScore : EntityBase
    {
        private decimal score;

        public decimal Score { 
            get { return score; }
            set 
            {
                if (score >= 0 && score <= 5)
                    score = value;
                else
                    throw new ArgumentException("The review cannot be below 0 or over 5.");
            } 
        }  

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public ReviewScore(int id) : base(id)
        {
        }
    }
}
