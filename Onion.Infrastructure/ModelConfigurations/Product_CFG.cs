using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;


namespace Onion.Infrastructure.ModelConfigurations
{
    public class Product_CFG : BaseEntityConfiguration<Product>, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ProductName)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.Description)
              .HasColumnType("varchar")
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.Price)
              .HasColumnType("money")
              .IsRequired();

            builder.Property(x => x.Stock)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Image)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(false)
                .HasDefaultValue("bosResim.jpg");

          
        }
    }
}
