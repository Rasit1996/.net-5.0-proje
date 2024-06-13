using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Validation;
using EntityLayer.Entity;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class KayitController : Controller
	{
		BContext ctx=new BContext();
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Yazar y)
		{
			YazarDogrulama yd=new YazarDogrulama();
			ValidationResult durum=yd.Validate(y);
			if (!durum.IsValid)
			{
				foreach (var item in durum.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();

			}
			y.Durum = true;
			y.Hakkinda = "İlk kayıt";
			ctx.yazars.Add(y);
			ctx.SaveChanges();
			return RedirectToAction("Index","Blok");
		}
	}
}
