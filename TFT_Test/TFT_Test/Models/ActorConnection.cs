namespace TFT_Test.Models
{
	public class ActorConnection
    {
		public int ActorConnectionId { get; set; }
		public Actor ConnectedActor { get; set; }
		public Film ConnectedFilm { get; set; }

		public bool Accepted { get; set; }
	}
}
