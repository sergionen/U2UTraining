using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;

namespace WebShop.Infra.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.HasKey(p => p.Id);

            product.Property(p => p.Provider).HasMaxLength(30);

            product.Property(p => p.Name).HasMaxLength(50).IsRequired(); 
            
            product.Property(p => p.ProductCategory).HasMaxLength(10).HasConversion<string>();
            
            product.HasMany(p => p.ReviewsScores)
                .WithOne(r => r.Product)
                .OnDelete(DeleteBehavior.Cascade); 
            
            product.Property(p => p.Price).HasColumnType("decimal(8,3)");

            product.HasData(

            new Product(1)
            {
                Name = "Avocado",
                ImgUrl = "assets/imgs/shop/product-9-1.jpg",
                Price = 34.6M,
                Provider = "Amazon",
                ProductCategory = ProductCategory.Vegetables,
                Description = "Delicious avocado",
                Discount = 0,
        },

            new Product(2)
            {
                Name = "Nuts",
                ImgUrl = "assets/imgs/shop/product-3-1.jpg",
                Price = 4.9M,
                Provider = "Amazon",
                ProductCategory = ProductCategory.Snack,
                Description = "Delicious nuts",
                Discount = 50,
            },

            new Product(3)
            {
                Name = "Stake Meat",
                ImgUrl = "assets/imgs/shop/product-2-1.jpg",
                Price = 64.6M,
                Provider = "MeatMarket",
                ProductCategory = ProductCategory.Meats,
                Description = "Delicious Stake",
                Discount = 20,
            },

            new Product(4)
            {
                Name = "Bottle of water",
                ImgUrl = "assets/imgs/shop/product-1-1.jpg",
                Price = 0.6M,
                Provider = "Fuentsanta",
                ProductCategory = ProductCategory.All,
                Description = "Delicious Water",
                Discount = 0,
            });
        }
    }
}
