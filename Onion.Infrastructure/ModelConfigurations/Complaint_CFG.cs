using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Infrastructure.ModelConfigurations
{
    public class Complaint_CFG : BaseEntityConfiguration<Complaint>, IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Subject)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(150)
               .IsRequired();
            builder.Property(x => x.Response)
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired(false);
        }
    }
}
