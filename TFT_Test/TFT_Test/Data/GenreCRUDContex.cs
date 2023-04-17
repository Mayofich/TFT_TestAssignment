using Microsoft.EntityFrameworkCore;
using TFT_Test.Models;

namespace TFT_Test.Data
{
	public class GenreCRUDContext : DbContext
	{
		public GenreCRUDContext(DbContextOptions<GenreCRUDContext> options) : base(options) { }
		public DbSet<Genre> Genre { get; set; }

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
