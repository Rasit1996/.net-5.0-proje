using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccessLayer.Validation;
using FluentValidation.Results;
using EntityLayer.Entity;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KatController : Controller
    {
        BContext ctx=new BContext();

        //[Route("")]
        public IActionResult Index()
        {
            //ViewBag.adet=ctx.kategoris.SingleOrDefault().bloks.Count();
            var liste=ctx.kategoris.Include(x => x.bloks).ToList();
            return View(liste);
        }

        public PartialViewResult SolMenu()
        {
            return  PartialView();
        }
        [HttpPost]
        public IActionResult Sil(int id)
        {
            ctx.kategoris.Remove(ctx.kategoris.SingleOrDefault(x=>x.ID==id));
            ctx.SaveChanges(); 
            return Ok();
        }

        public IActionResult Duzenle(int id) 
        {
            var kat=ctx.kategoris.SingleOrDefault(x=>x.ID==id);
            return View(kat);
        }

        [HttpPost]
        public IActionResult  Duzenle(Kategori k)
        {
            k.Durum = true;
            ctx.kategoris.Update(k);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Kategori k)
        {
            KategoriDogrulama kd = new KategoriDogrulama();
            ValidationResult result = kd.Validate(k);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            k.Durum = true;
            ctx.kategoris.Add(k);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

     
    }
}
