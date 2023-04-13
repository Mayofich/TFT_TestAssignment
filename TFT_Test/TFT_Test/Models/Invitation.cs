namespace TFT_Test.Models
{
	public class Invitation
	{
		public int InvitationId { get; set; }
		public Actor InvitedActor { get; set; }
		public Film FilmInvitedTo { get; set; }
	}
}
