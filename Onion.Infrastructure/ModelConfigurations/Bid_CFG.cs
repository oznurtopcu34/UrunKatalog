using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Infrastructure.ModelConfigurations
{
    public class Bid_CFG : BaseEntityConfiguration<Bid>, IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
           
            builder.Property(b => b.Name)
                   .HasMaxLength(100)
                   .IsRequired(); // Kullanıcı adı zorunlu

            builder.Property(b => b.Email)
                   .HasMaxLength(200)
                   .IsRequired(); // Email zorunlu

            builder.Property(b => b.Phone)
                   .HasMaxLength(20)
                   .IsRequired(); // Telefon zorunlu

            builder.Property(b => b.OfferedPrice)
                   .HasColumnType("money")
                   .IsRequired(); // Teklif fiyatı zorunlu

            builder.Property(b => b.CreatedDate)
                   .HasColumnType("datetime2")
                   .IsRequired(); // Teklifin oluşturulma tarihi

           
        }
    }
}
