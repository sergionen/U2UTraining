using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entities
{
    public class Product : EntityBase
    {

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            
            set 
            { 
                if (value >= 0) 
                    _price = value; 
                else
                    throw new ArgumentOutOfRangeException("The price cannot be negative.");
            } 
        }

        public string Provider { get; set; } = default!;

        public string ImgUrl { get; set; } = default!;

        public IList<ReviewScore> ReviewsScore { get; set; } = new List<ReviewScore>();

        public ProductCategory ProductCategory { get; set; }

        public Product(int id) : base(id)
        {
        }

        public decimal GetReviewScore()
        {
            if (ReviewsScore.Count() != 0)
                return ReviewsScore.Average(r => r.Score);
            return 0;
        }

        public double GetStarsPercentage()
        {
            if (GetReviewScore() == 0)
                return 0;
            return (double)GetReviewScore() / 5 * 100;
        }
    }
}
