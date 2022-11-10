using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;
using WebShop.Infra.Configuration;

namespace WebShop.Infra.Repositories
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<ReviewScore> ReviewScores => Set<ReviewScore>();
        public DbSet<Order> Order => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfiguration(new ReviewScoreConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }


    }
}
