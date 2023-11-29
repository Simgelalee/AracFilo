using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AracFilo.Models.utility
{
    public class UygulamaDbContext:IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext>options) : base(options) { }
        //EF isiminin VT karşilığı (s)
      //  public DbSet<CarVito> CarVitos { get; set; }
        public DbSet<Arac> Araclar { get; set; }
		public DbSet<Rent> Rents{ get; set; }

	}
}

