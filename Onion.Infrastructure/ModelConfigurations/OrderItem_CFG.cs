using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Infrastructure.ModelConfigurations
{
    public class OrderItem_CFG : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder.Property(x => x.Price)
                .HasColumnType("money")
                .IsRequired();
            builder.Property(x => x.Quantity)
               .HasColumnType("int")
               .IsRequired();
        }
    }
}
