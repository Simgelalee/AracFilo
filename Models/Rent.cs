using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AracFilo.Models
{
	public class Rent
	{
		[Key]
		public int RentId { get; set; }

       

        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }

		public string Carplate { get; set; }

        public string Destination { get; set; }

        public string Durum { get; set; }
        public int AracId { get; set; }
        public virtual Arac Arac { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }


    }
}
