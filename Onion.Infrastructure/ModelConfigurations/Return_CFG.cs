using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Infrastructure.ModelConfigurations
{
    public class Return_CFG : BaseEntityConfiguration<Return>, IEntityTypeConfiguration<Return>
    {
        public void Configure(EntityTypeBuilder<Return> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ReturnDate)
                 .HasColumnType("smalldatetime")
                 .IsRequired();

            builder.Property(x => x.Reason)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
