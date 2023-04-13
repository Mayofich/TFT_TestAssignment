using Microsoft.EntityFrameworkCore;
using TFT_Test.Models;

namespace TFT_Test.Data
{
	public class FilmListContext : DbContext
	{
		public FilmListContext(DbContextOptions<FilmListContext> options) : base(options) { }
		public DbSet<Film> Films { get; set; }

	}
}
