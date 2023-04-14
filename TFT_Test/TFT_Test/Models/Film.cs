namespace TFT_Test.Models
{
	public class Film
	{
		public int FilmId { get; set; }
		public string FilmName { get; set; }
		public string FilmDescription { get; set;}
		public TimeSpan FilmLengt { get; set; }
		public DateTime? StartedFilming { get; set; }
		public DateTime? EndedFilming { get; set; }
		public ICollection<Genre> FilmGenre { get; set;}
		public ICollection<Invitation>? ActorInvitations { get; set; }
		public ICollection<Actor>? ConfirmedActors { get; set; }
		public Director FilmDirector { get; set; }

	}
}
