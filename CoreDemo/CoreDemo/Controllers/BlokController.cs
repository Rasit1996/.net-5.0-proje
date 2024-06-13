using DataAccessLayer.Context;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
	
	public class BlokController : Controller
	{
		BContext ctx = new BContext();
		public IActionResult Index()
		{
			var blok=ctx.bloks.Include(x=>x.kategori).Include(x=>x.yorumcus).ToList();
			return View();
		}

		public IActionResult Detaylar(int id)
		{
			try
			{
                ViewBag.blog = id;
                ViewBag.yazar = ctx.bloks.SingleOrDefault(x => x.ID == id).UserID;
                return View(ctx.bloks.SingleOrDefault(x => x.ID == id));
            }
			catch (System.Exception)
			{

				return RedirectToAction("Index");
			}
			
		}
		public IActionResult a()
		{
			
			return View();
		}

		//public PartialViewResult Abone(int id)
		//{
		//	ViewBag.blog = id;
		//	return PartialView();
		//}

		//[HttpPost]
		//public IActionResult Abone(HaberBulteni hb,int Bid)
		//{
		//	hb.Durum = true;
		//	ctx.haberBultenis.Add(hb);
		//	ctx.SaveChanges();	
		//	return RedirectToAction("Detaylar", new {id=Bid});
		//}
		[HttpPost]
		public PartialViewResult Abone(HaberBulteni hb)
		{
			hb.Durum = true;
			ctx.haberBultenis.Add(hb);
			ctx.SaveChanges();
			return PartialView();
		}

		public void Yorum(Yorumcu y)
		{
			y.Durum = true;
			ctx.yorumcus.Add(y);
			ctx.SaveChanges();
			
		}


		//public PartialViewResult blogyeni(string id)
		//{
		//	List<Blok> blok;
		//	if (string.IsNullOrEmpty(id))
		//	{
		//		blok = ctx.bloks.Include(x => x.kategori).Include(x => x.yorumcus).ToList();
		//	}
		//	else
		//	{
		//		blok = ctx.bloks.Include(x => x.kategori).Include(x => x.yorumcus).Where(x => x.Baslik.Contains(id)).ToList();
		//	}


		//	return PartialView(blok);
		//}

		public IActionResult Invoke(string? id)
		{
			var result = ViewComponent("BlogYazilari", new {id});

			return result;
		}
	}
}
