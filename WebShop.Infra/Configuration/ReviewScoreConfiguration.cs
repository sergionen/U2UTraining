using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;

namespace WebShop.Infra.Configuration
{
    public class ReviewScoreConfiguration : IEntityTypeConfiguration<ReviewScore>
    {
        public void Configure(EntityTypeBuilder<ReviewScore> reviewScore)
        {
            reviewScore.HasKey(r => r.Id);

            reviewScore.Property(r => r.Score).HasColumnType("decimal(8,3)");

            //reviewScore.HasOne(r => r.Product).WithMany(p=>p.ReviewsScore);

            reviewScore.HasData(
                    new ReviewScore(1) { Score = 3, ProductId = 1 },
                    new ReviewScore(2)  { Score = 3.1M, ProductId = 2 },
                    new ReviewScore(3)  { Score = 5, ProductId = 2 },
                    new ReviewScore(4)  { Score = 1, ProductId = 2 },
                    new ReviewScore(5)  { Score = 3, ProductId = 3 },
                    new ReviewScore(6)  { Score = 0.9M, ProductId = 3 },
                    new ReviewScore(7)  { Score = 3.7M, ProductId = 3 },
                    new ReviewScore(12) { Score = 5, ProductId = 4 }
                );
        }
    }
}
