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
    public class Cart_CFG : BaseEntityConfiguration<Cart>, IEntityTypeConfiguration<Cart> 
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            base.Configure(builder);
        
        }
    }
}
