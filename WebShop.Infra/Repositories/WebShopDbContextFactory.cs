using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Infra.Repositories
{
    public class WebShopDbContextFactory : IDesignTimeDbContextFactory<WebShopDbContext>
    {
        public WebShopDbContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder? cb = new ConfigurationBuilder();
            cb.AddUserSecrets<WebShopDbContext>();
            IConfigurationRoot configuration = cb.Build();
            
            string connectionString = configuration.GetConnectionString("WebShopDb");
            
            DbContextOptionsBuilder<WebShopDbContext>? builder = new DbContextOptionsBuilder<WebShopDbContext>();
            
            builder.UseSqlServer(connectionString);
            
            builder.EnableSensitiveDataLogging();
            
            return new WebShopDbContext(builder.Options);
        }
    }
}
