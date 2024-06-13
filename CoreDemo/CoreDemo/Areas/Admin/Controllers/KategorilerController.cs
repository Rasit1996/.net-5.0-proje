using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Context;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategorilerController : Controller
    {
        BContext ctx=new BContext();
        public IActionResult Index()
        {
            var kats=ctx.kategoris.ToList();
            return View(kats);
        }

        public IActionResult Sil(int id)
        {
            var kat=ctx.kategoris.FirstOrDefault(x=>x.ID==id);
            ctx.kategoris.Remove(kat);
            ctx.SaveChanges();
            return Ok();
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Ekle(kategori k)
        {

            if (!ModelState.IsValid)
                return View(k);

            Kategori kat = new Kategori();
            kat.Adi = k.Adi;
            kat.Durum = true;
            ctx.kategoris.Add(kat);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
