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
    public class ContentCategory_CFG :BaseEntityConfiguration<ContentCategory>,IEntityTypeConfiguration<ContentCategory>
    {
        public void Configure(EntityTypeBuilder<ContentCategory> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ContentCategoryName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            builder.HasData(
                  new ContentCategory { ContentCategoryID = 1, ContentCategoryName = "Teknoloji" },
                  new ContentCategory { ContentCategoryID = 2, ContentCategoryName = "Bilimsel Gelişmeler" },
                  new ContentCategory { ContentCategoryID = 3, ContentCategoryName = "Spor" }
               
                );

        }

    }
}
