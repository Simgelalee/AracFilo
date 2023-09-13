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
			List<SelectListItem> selectListItems=Araclar.Select(x=> new SelectListItem(x.Plaka,x.AracId.ToString())).ToList();
			ViewData["Araclar"] = selectListItems;
		}
		[HttpGet]
		public IActionResult RentAdd(int? id)
		{
			_db.Rents.Add(new Rent());
			List<SelectListItem> valueRent = (from x in _db.Araclar.Where(x => x.Status == true).ToList()
			                                  select new SelectListItem
											  { Text= $"{x.Plaka}-{x.Vito}",
											    Value=x.AracId.ToString()
											  }).ToList();
			ViewBag.Rent = valueRent;
			var arac = _db.Araclar.Find(id);
			


			if (arac == null)
			{
				return NotFound();
			}
			var rented = new Rent();
			rented.AracId = arac.AracId;
			rented.Carplate = arac.Plaka;
			return View(rented);
		}

		private void ToList()
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public IActionResult RentAdd(Rent rent)
		{
			
			var userDetail = HttpContext.User.Identity.Name;
			var user = _db.Users.Where(x => x.Email == userDetail).FirstOrDefault();
			
			//var Status=_db.Rents.Where(x => x.CreatedDate<rent.CreatedDate && x.CreatedDate<rent.EndDate && x.EndDate < rent.CreatedDate && x.EndDate < rent.EndDate).ToList()
			User user1 = new User();
			user1.UserEmail = user.Email;
			user1.UserName = user.UserName;
			
			
			_db.Rents.Add(rent);
			_db.Mahmut.Add(user1);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Index()
		{
			var rents = _db.Rents.ToList();

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
		public IActionResult Guncelle(Rent rent)
		{
			if (rent.AracId == null || rent.Carplate == null)
			{
				ModelState.AddModelError(string.Empty, "Boş geçilemez");
				return View(rent);
			}
			
				_db.Rents.Update(rent);
				_db.SaveChanges();

				return RedirectToAction("Index");
			

		}

	}

}
