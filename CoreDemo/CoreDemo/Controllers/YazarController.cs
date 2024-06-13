using DataAccessLayer.Context;
using DataAccessLayer.Validation;
using EntityLayer.Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
	
	public class YazarController : Controller
	{
		BContext ctx=new BContext();
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Bloglarım()
		{
			if (!User.Identity.IsAuthenticated)
			{
				return View("Index");
			}
			var blogs=ctx.bloks.Include(x=>x.kategori).Where(x=>x.User.UserName==User.Identity.Name).ToList();
			return View(blogs);
		}

		[HttpPost]

		public IActionResult Sil(int id)
		{
			var blog = ctx.bloks.Find(id);
			ctx.bloks.Remove(blog);
			ctx.SaveChanges();
			return Ok();

		}

		public IActionResult Düzenle(int id)
		{
			int ID=ctx.bloks.SingleOrDefault(x=>x.ID==id).KategoriID;
			ViewBag.kat = ctx.kategoris.Where(x => x.ID != ID).ToList();
			return	View(ctx.bloks.Include(x=>x.kategori).SingleOrDefault(x=>x.ID==id));
		}

		[HttpPost]

		public IActionResult Düzenle(Blok b)
		{
			b.Durum = "true";

			ctx.bloks.Update(b);
			ctx.SaveChanges();
			return RedirectToAction("Bloglarım");	

		}

		public IActionResult BlogEkle() 
		{
			int id = ctx.Users.SingleOrDefault(x => x.UserName == User.Identity.Name).Id;
			ViewBag.id = id;
			ViewBag.kat=ctx.kategoris.ToList();
			return View();
		}

		[HttpPost]

		public  IActionResult BlogEkle(Blok b, IFormFile fileUpload)
		{
			BlokDogrulama val = new BlokDogrulama();
			ValidationResult result=val.Validate(b);
			if (!result.IsValid)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
                int id = ctx.Users.SingleOrDefault(x => x.UserName == User.Identity.Name).Id;
                ViewBag.id = id;
                ViewBag.kat = ctx.kategoris.ToList();
				return View();

			}
			if (fileUpload==null)
			{
                b.Durum = "true";
                ctx.bloks.Add(b);
                ctx.SaveChanges();
                return RedirectToAction("Bloglarım");
            }
			string yol = "/CoreBlogTema/Resimler/"+ Guid.NewGuid()+ Path.GetExtension(fileUpload.FileName);
			var dosya = "wwwroot" + yol;
			var fileStream=new FileStream(dosya, FileMode.Create);
			fileUpload.CopyTo(fileStream);

			b.ImageUrl = yol;
			b.Durum="true";
			ctx.bloks.Add(b);
			ctx.SaveChanges();
			return RedirectToAction("Bloglarım");
		}

		//[Route("Profilim")]
		public IActionResult Profilim()
		{
			var yazar=ctx.Users.SingleOrDefault(x=>x.UserName == User.Identity.Name);
			var email=User.Claims.SingleOrDefault(x=>x.Type==ClaimTypes.Email).Value;
			
            return View(yazar);
		}

		public IActionResult ProfilGuncelle()
		{
			var yazar=ctx.Users.SingleOrDefault(x=>x.UserName==User.Identity.Name);
			return View(yazar);
		}

		[HttpPost]
        public IActionResult ProfilGuncelle(Yazar y,string SifreTekrar, IFormFile Image)
        {
			YazarDogrulama yd = new YazarDogrulama();
			ValidationResult result=yd.Validate(y);
			if (result.IsValid)
			{
				if (y.Sifre==SifreTekrar)
				{
					string url = ctx.yazars.AsNoTracking().SingleOrDefault(x => x.ID == y.ID).ImageUrl;
					if (Image != null && (url == null||url!=null))
					{
						string yol = "/CoreBlogTema/Resimler/" + Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
						string dosya = "wwwroot/" + yol;
						var filestream=new FileStream(dosya, FileMode.Create);
						Image.CopyTo(filestream);
						y.ImageUrl = yol;
					}
					else if(Image == null && url != null)
					{
						y.ImageUrl= url;
					}
					y.Durum = true;
					
					ctx.yazars.Update(y);
					ctx.SaveChanges();
					return RedirectToAction("Profilim");
				}
				else
				{
					ViewBag.hata = "Şifreler Aynı değil. Lütfen tekrar deneyiniz.";
                    var ya = ctx.yazars.SingleOrDefault(x => x.Adi == User.Identity.Name);
					return View(ya);
                }
			}

			foreach (var item in result.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}

            var yazar = ctx.yazars.SingleOrDefault(x => x.Adi == User.Identity.Name);
            return View(yazar);
        }

		public IActionResult Bildirimler()
		{
			var bildirim=ctx.bildirims.Include(x=>x.user).Where(x=>x.user.UserName ==User.Identity.Name).ToList();
			return View(bildirim);
		}

		public IActionResult gelenmesajlar()
		{
			var mesajlar=ctx.mesajUsers.Include(x=>x.Gonderen).Include(x=>x.Alici).Where(x=>x.Alici.UserName==User.Identity.Name).ToList();
			return View(mesajlar);
		}

		public IActionResult MesajDetay(int id,string tip)
		{
			var mesaj=new MesajUser();
				
			if (tip == "detay2")
			{
				mesaj = ctx.mesajUsers.Include(x => x.Alici).SingleOrDefault(x => x.ID == id);
			}
			else
			{
				mesaj = ctx.mesajUsers.Include(x => x.Gonderen).SingleOrDefault(x => x.ID == id);
			}
			ViewBag.tip = tip;
			return View(mesaj);	
		}

		public IActionResult gidenmesajlar()
		{
			var mesajlar=ctx.mesajUsers.Include(x=>x.Alici).Where(x=>x.Gonderen.UserName==User.Identity.Name).ToList();
			return View(mesajlar);

		}
    }
}
