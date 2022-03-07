using Microsoft.EntityFrameworkCore;
using NetFlex.Core.Models;

namespace NetFlex.Infrastructure
{
	public class DatabaseContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DatabaseContext(DbContextOptions options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
