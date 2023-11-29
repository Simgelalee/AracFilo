using Microsoft.AspNetCore.Identity;
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
        public bool Status { get; set; }
        public string Durum { get; set; }
        public int AracId { get; set; }
        public virtual Arac Arac { get; set; }
		public string UserId { get; set; }
        public string ResimUrl { get; set; }

    }
}
