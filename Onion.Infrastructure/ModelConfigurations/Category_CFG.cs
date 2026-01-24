using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Infrastructure.ModelConfigurations
{
    public class Category_CFG :BaseEntityConfiguration<Category>,IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CategoryName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            builder.HasData(
                new Category { CategoryID = 1, CategoryName = "Bilgisayar ve aksesuarları" },
                new Category { CategoryID = 2, CategoryName = "Telefon ve aksesuarları" },  
                new Category { CategoryID = 3, CategoryName = "Küçük ev aletleri." },
                new Category { CategoryID = 4, CategoryName = "Yazıcılar" }
                );

        }
    }
}
