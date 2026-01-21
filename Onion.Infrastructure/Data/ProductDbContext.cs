using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onion.Domain.Models;
using System.Reflection;

namespace Onion.Infrastructure.Data
{
    public class ProductDbContext : IdentityDbContext<User,Role,int>
    {
        public ProductDbContext()
        {
            
        }

        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<ReturnItem> ReturnItems { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ContentCategory> ContentCategories { get; set; }
        public DbSet<BlogPost> BlogsPosts { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Bid> Bids { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=DESKTOP-88RQL31\\SQLEXPRESS;initial catalog=HS16_ProductDB;integrated security=true;trust server certificate=true");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 2 },
                 new IdentityUserRole<int> { UserId = 3, RoleId = 3 });

        }



    }


    
}
