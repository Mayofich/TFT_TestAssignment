using Microsoft.EntityFrameworkCore;
using TFT_Test.Models;

namespace TFT_Test.Data
{
	public class DirectorCRUDContext : DbContext
	{
		public DirectorCRUDContext(DbContextOptions<DirectorCRUDContext> options) : base(options) { }
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
