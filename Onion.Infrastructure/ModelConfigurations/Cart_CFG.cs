using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Models;

namespace Onion.Infrastructure.ModelConfigurations
{
    public class Cart_CFG : BaseEntityConfiguration<Cart>, IEntityTypeConfiguration<Cart> 
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            base.Configure(builder);
        
        }
    }
}
