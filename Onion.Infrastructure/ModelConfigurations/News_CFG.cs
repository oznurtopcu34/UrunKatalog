using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Infrastructure.ModelConfigurations
{
    public class News_CFG : BaseEntityConfiguration<News>, IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnType("varchar")
                .HasMaxLength(1500)
                .IsRequired();

            builder.Property(x => x.Image)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired(false)
               .HasDefaultValue("bosResim.jpg");
        }
    }
}
