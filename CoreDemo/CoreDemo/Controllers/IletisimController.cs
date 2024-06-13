using DataAccessLayer.Context;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	public class IletisimController : Controller
	{
		BContext ctx=new BContext();
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(İletisim i)
		{
			i.Durum = true;
			i.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
			ctx.iletisims.Add(i);
			ctx.SaveChanges();
			return View();
		}
	}
}
