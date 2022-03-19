using Microsoft.EntityFrameworkCore;
using NetFlex.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NetFlex.DAL.EF
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}