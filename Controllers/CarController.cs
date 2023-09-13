using AracFilo.Context;
using AracFilo.Models;
using AracFilo.Models.utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AracFilo.Controllers
{
	//[Authorize(Roles = UserRoles.Role_Admin)]
	public class CarController : Controller
	{
		private readonly UygulamaDbContext _db;

		public CarController(UygulamaDbContext db)
		{
			_db = db;
		}
		[HttpGet]
		public IActionResult CarAdd()
		{

			return View();
		}
		[HttpPost]
		public IActionResult CarAdd(Arac arac)
		{
			if (arac.AracName == null || arac.Plaka == null || arac.Ozellik == null)
			{
				ModelState.AddModelError(string.Empty, "Boş geçilemez");
				return View(arac);
			}
			_db.Araclar.Add(arac);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Index()
		{
			var cars = _db.Araclar.ToList();

			return View(cars);
		}
		[HttpGet]
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
		public IActionResult Guncelle(Arac arac)
		{
			if (arac.AracName == null || arac.Plaka == null || arac.Ozellik == null)
			{
				ModelState.AddModelError(string.Empty, "Boş geçilemez");
				return View(arac);
			}
			if (ModelState.IsValid) {
				_db.Araclar.Update(arac);
				_db.SaveChanges();

				return RedirectToAction("Index", "Car");
			}
			return View();


		}
		
	}
}