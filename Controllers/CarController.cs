using AracFilo.Context;
using AracFilo.Models;
using AracFilo.Models.utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AracFilo.Controllers
{
	
	public class CarController : Controller
	{
		private readonly UygulamaDbContext _db;

		public CarController(UygulamaDbContext db)
		{
			_db = db;
		}
		[HttpGet]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult CarAdd()
		{

			return View();
		}
		[HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult CarAdd(Arac arac)
		{
			if (arac.AracName == null || arac.Plaka == null || arac.Ozellik == null)
			{
				
				ModelState.AddModelError(string.Empty, "Boş geçilemez");
				return View(arac);
			}
            
            _db.Araclar.Add(arac);
			_db.SaveChanges();
			return RedirectToAction("Index","Car");
		}

		[HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
		{
			var cars = _db.Araclar.ToList();
			

			return View(cars);
		}
		[HttpGet]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Sil(int id)
		{
			var arac = _db.Araclar.Find(id);

			if (arac == null)
			{
				return NotFound();
			}

			return View(arac);
		}



		[HttpPost,ActionName("Sil")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult SilPost(int id)
		{
			var arac = _db.Araclar.Find(id);

			if (arac == null)
			{
				return NotFound();
			}

			_db.Araclar.Remove(arac);
			_db.SaveChanges();

			return RedirectToAction("Index");
		}
		[HttpGet]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Guncelle(int? id)

		{
			var arac = _db.Araclar.Find(id);

			if (arac == null)
			{
				return NotFound();
			}
			return View(arac);
		}
		[HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Guncelle(Arac arac)
        {

            
            if (arac.AracName == null || arac.Plaka == null || arac.Ozellik == null)
			{
               
                ModelState.AddModelError(string.Empty, "Boş geçilemez");
				return View(arac);
			}
            
           
                
                _db.Araclar.Update(arac);
				_db.SaveChanges();

				return RedirectToAction("Index", "Car");
			


		}
		
	}
}