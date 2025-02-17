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
    public class ReturnItem_CFG : BaseEntityConfiguration<ReturnItem>, IEntityTypeConfiguration<ReturnItem>
    {
        public void Configure(EntityTypeBuilder<ReturnItem> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Quantity)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
