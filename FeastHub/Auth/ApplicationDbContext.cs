using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FeastHub;
using System.Reflection.Emit;

namespace FeastHub.Auth
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.Entity<Order>().OwnsOne(x => x.CartItem);
        }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Menu> Menue { get; set; }
        public DbSet<OperatingHours> OperatingHour { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
    }

}
