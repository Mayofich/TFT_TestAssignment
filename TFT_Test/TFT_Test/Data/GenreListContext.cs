using Microsoft.EntityFrameworkCore;
using TFT_Test.Models;

namespace TFT_Test.Data
{
	public class GenreListContext : DbContext
	{
		public GenreListContext(DbContextOptions<GenreListContext> options) : base(options) { }
		public DbSet<Genre> Genres { get; set; }

	}
}
