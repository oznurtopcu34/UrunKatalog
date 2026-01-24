using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Infrastructure.ModelConfigurations
{
    public class FAQ_CFG : BaseEntityConfiguration<FAQ>, IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Question)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.Answer)
               .HasColumnType("varchar")
               .HasMaxLength(150)
               .IsRequired(false);
        }
    }
}
