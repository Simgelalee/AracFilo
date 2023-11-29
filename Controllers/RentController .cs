using AracFilo.Context;
using AracFilo.Models;
using AracFilo.Models.utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AracFilo.Controllers
{
	//[Authorize(Roles =UserRoles.Role_Admin )]
	public class RentController : Controller
	{
		private readonly UygulamaDbContext _db;

		public RentController(UygulamaDbContext db)
		{
			_db = db;
		}

		private void DataToView()
		{

			List<Arac> Araclar = _db.Araclar.ToList();
			List<SelectListItem> selectListItems = Araclar.Select(x => new SelectListItem(x.Plaka, x.AracId.ToString())).ToList();
			ViewData["Araclar"] = selectListItems;
		}
		[HttpGet]
		public IActionResult RentAdd(int? id)


		{
			var arac = _db.Araclar.Find(id);

			var rented = new Rent();
			rented.AracId = arac.AracId;
			rented.Carplate = arac.Plaka;


			_db.Rents.Add(new Rent());
			List<SelectListItem> valueRent = (from x in _db.Araclar.Where(x => x.Status == true).ToList()
											  select new SelectListItem
											  {
												  Text = $"{x.Plaka}-{x.Vito}",
												  Value = x.AracId.ToString()
											  }).ToList();
			ViewBag.Rent = valueRent;



			if (arac == null)
			{
				return NotFound();
			}

			return View(rented);
		}

		private void ToList()
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public IActionResult RentAdd(Rent rent)
		{
			var rento = _db.Rents.Where(x => x.AracId == rent.AracId).FirstOrDefault();

			if (rento == null)
			{
				var userDetail = HttpContext.User.Identity.Name;
				var user = _db.Users.Where(x => x.Email == userDetail).FirstOrDefault();

				rent.UserId = user.Email;
				rent.ResimUrl = " ";
				_db.Rents.Add(rent);

				_db.SaveChanges();
				return RedirectToAction("Index");

			}
			ModelState.AddModelError(string.Empty, "Bu araç dolu");
			return View(rent);
		}
		[HttpGet]
		public IActionResult Index()
		{
			var rents = _db.Rents.ToList();
			foreach (var item in rents)
			{
				var deneme = _db.Araclar.Find(item.AracId);
				ViewData[$"{item.AracId}"] = deneme.AracName;
			}



			return View(rents);
		}
		[HttpGet]
		public IActionResult Sil(int id)
		{
			var rent = _db.Rents.Find(id);

			if (rent == null)
			{
				return NotFound();
			}

			return View(rent);
		}



		[HttpPost, ActionName("Sil")]
		public IActionResult SilPost(int id)
		{
			var rent = _db.Rents.Find(id);

			if (rent == null)
			{
				return NotFound();
			}

			_db.Rents.Remove(rent);
			_db.SaveChanges();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Guncelle(int? id)

		{
			var rent = _db.Rents.Find(id);

			if (rent == null)
			{
				return NotFound();
			}
			return View(rent);
		}
		[HttpPost]
		public IActionResult Guncelle(int id, Rent rent)
		{
			if (rent.AracId == null || rent.UserId == null || rent.Carplate == null)
			{

				ModelState.AddModelError(string.Empty, "Boş geçilemez");
				return View(rent);
			}
			var userDetail = HttpContext.User.Identity.Name;
			var user = _db.Users.Where(x => x.Email == userDetail).FirstOrDefault();

			var rentData = _db.Rents.FirstOrDefault(f => f.RentId == id);

			rentData.UserId = user.Email;
			rentData.Status = rent.Status;
			rentData.ResimUrl = " ";

			_db.Rents.Update(rentData);
			_db.SaveChanges();

			return RedirectToAction("Index", "Rent");


		}


	}


	//public bool IsReserveCar()
	//{

	//}

}


