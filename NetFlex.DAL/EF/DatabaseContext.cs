using Microsoft.EntityFrameworkCore;
using NetFlex.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetFlex.DAL.EF
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<GenreVideo> GenreVideos { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
    }

    //public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    //{
    //    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    //    {
    //        builder.Property(u => u.Avatar);
    //    }
    //}
}