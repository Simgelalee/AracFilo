using System.ComponentModel.DataAnnotations;

namespace AracFilo.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		
		public string UserName { get; set; }

		public string UserEmail { get; set; }


		public virtual List<Arac> Aracs { get; set; }
		public virtual List<Rent> rents { get; set; }
		
	}
}
