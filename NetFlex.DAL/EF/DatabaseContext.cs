using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NetFlex.DAL.Entities;

namespace NetFlex.DAL.EF;

public class DatabaseContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Serial> Serials { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<UserSubscription> UserSubscriptions { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {

    }

    public DatabaseContext(string connectionString)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}
