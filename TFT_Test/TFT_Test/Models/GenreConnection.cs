namespace TFT_Test.Models
{
	public class GenreConnection
    {
		public int GenreConnectionId { get; set; }
		public Genre GenreConnected { get; set; }
		public Film FilmConnected { get; set; }

	}
}
