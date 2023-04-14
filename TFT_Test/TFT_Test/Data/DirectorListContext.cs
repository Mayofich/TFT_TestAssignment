using Microsoft.EntityFrameworkCore;
using TFT_Test.Models;

namespace TFT_Test.Data
{
	public class DirectorListContext : DbContext
	{
		public DirectorListContext(DbContextOptions<DirectorListContext> options) : base(options) { }
		public DbSet<Director> Directors { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public override int SaveChanges()
		{
			ChangeTracker.DetectChanges();
			return base.SaveChanges();
		}
	}
}
