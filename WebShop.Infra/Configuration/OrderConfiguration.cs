using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Entities;
using static System.Formats.Asn1.AsnWriter;

namespace WebShop.Infra.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            order.HasKey(o => o.Id);

            order.HasMany(o => o.Products)
                .WithOne();

            order.Property(o => o.Total).HasColumnType("decimal(8,3)");

        }
        
    }
}
