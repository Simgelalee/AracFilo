using System.ComponentModel.DataAnnotations;

namespace AracFilo.Models
{
	public class Arac
	{
		[Key]
		public int AracId { get; set; }
		
		public string AracName { get; set; }

        public string Plaka { get; set; }

        public string Ozellik { get; set; }
        public bool Status { get; set; }

       public string Vito { get; set; }

		public int UserId { get; set; }
		public virtual User User { get; set; }

		public virtual List<Rent> Rents { get; set; }
		





		// bire bir bire çok ilişki prop
	}
}
