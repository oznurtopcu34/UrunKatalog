using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Abstract;
using Onion.Domain.Enums;

namespace Onion.Infrastructure.ModelConfigurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity

    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property("CreatedDate")
                .HasColumnType("smalldatetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property("UpdatedDate")
                .HasColumnType("smalldatetime")
                .IsRequired(false);

            builder.Property("DeletedDate")
                .HasColumnType("smalldatetime")
                .IsRequired(false);
            builder.Property(x => x.RecordStatus)
                .HasDefaultValue(RecordStatus.NewRecord);

        }
    }
}
