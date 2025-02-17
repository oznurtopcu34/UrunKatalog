using Microsoft.AspNetCore.Identity;
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
    public class User_CFG : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsRequired();
            builder.Property(x => x.LastName)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsRequired();

            User superAdmin = new User()
            {
                Id = 1,
                FirstName = "Super",
                LastName = "Admin",
                UserName = "sprAdmn",
                NormalizedUserName = "SPRADMN",
                Email = "superadmin@deneme.com",
                NormalizedEmail = "SUPERADMIN@DENEME.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false
            };

            // Content Manager Kullanıcısı
            User contentManager = new User()
            {
                Id =2,
                FirstName = "Content",
                LastName = "Manager",
                UserName = "cntMgr",
                NormalizedUserName = "CNTMGR",
                Email = "contentmanager@deneme.com",
                NormalizedEmail = "CONTENTMANAGER@DENEME.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false
            };

            User customerService = new User()
            {
                Id = 3,
                FirstName = "Customer",
                LastName = "Service",
                UserName = "cstSrv",
                NormalizedUserName = "CSTSRV",
                Email = "customerservice@deneme.com",
                NormalizedEmail = "CUSTOMERSERVICE@DENEME.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            superAdmin.PasswordHash = hasher.HashPassword(superAdmin, "sprAdmn_123");
            contentManager.PasswordHash = hasher.HashPassword(contentManager, "cntMgr_123");
            customerService.PasswordHash = hasher.HashPassword(customerService, "cstSrv_123");

            builder.HasData(superAdmin, contentManager, customerService);
        }
    }
    
}
