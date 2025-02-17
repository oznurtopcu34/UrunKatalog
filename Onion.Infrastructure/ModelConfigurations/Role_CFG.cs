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
    public class Role_CFG : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
             new Role { Id = 1, Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new Role { Id = 2, Name = "ContentManager", NormalizedName = "CONTENTMANAGER", ConcurrencyStamp = Guid.NewGuid().ToString() },
             new Role { Id = 3, Name = "CustomerService", NormalizedName = "CUSTOMERSERVICE", ConcurrencyStamp = Guid.NewGuid().ToString() },
             new Role { Id = 4, Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() }
          
              );
        }
    }
}
