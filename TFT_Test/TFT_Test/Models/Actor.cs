using System.Security.Cryptography;

namespace TFT_Test.Models
{
	public class Actor
	{
		public int ActorId { get; set; }
		public string ActorName { get; set; }
		public string ActorSurname { get; set; }
		public string ActorAdress { get; set; }
		public int ExpectedFee { get; set; }
		public ICollection<Film> FinishedFilms { get; set;}
		public ICollection<Invitation> Invations { get; set;}
		public string ActorPassword { get; set; }
		public string ActorEmail { get; set; }

	}
}
