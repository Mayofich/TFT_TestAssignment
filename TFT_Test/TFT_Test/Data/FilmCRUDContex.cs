using Microsoft.EntityFrameworkCore;
using TFT_Test.Models;

namespace TFT_Test.Data
{
	public class FilmCRUDContext : DbContext
	{
		public FilmCRUDContext(DbContextOptions<FilmCRUDContext> options) : base(options) { }
		public DbSet<Film> Film { get; set; }

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
