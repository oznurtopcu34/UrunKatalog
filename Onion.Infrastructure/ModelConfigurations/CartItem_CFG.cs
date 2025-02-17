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
    public class CartItem_CFG : BaseEntityConfiguration<CartItem>, IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Price)
                .HasColumnType("money")
                .IsRequired();
            builder.Property(x => x.Quantity)
               .HasColumnType("int")
               .IsRequired();
        }
    }
}
