using DataAccessLayer.Context;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MesajController : Controller
    {
        BContext ctx=new BContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gelen()
        {
            var gelen=ctx.mesajUsers.Include(x=>x.Alici).Include(x=>x.Gonderen).Where(x=>x.Alici.UserName==User.Identity.Name).ToList();
            ViewBag.gelen= ctx.mesajUsers.Include(x => x.Alici).Where(x => x.Alici.UserName == User.Identity.Name).Count();
            return View(gelen);
        }
        public IActionResult Giden()
        {
           var giden=ctx.mesajUsers.Include(x=>x.Alici).Include(x=>x.Gonderen).Where(x=>x.Gonderen.UserName==User.Identity.Name).ToList();
            ViewBag.giden=ctx.mesajUsers.Include(x=>x.Gonderen).Where(x=>x.Gonderen.UserName==User.Identity.Name).Count();
            return View(giden);
        }

        public IActionResult Olustur()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Olustur(MesajUser mu,string email)
        {
            var alici=ctx.Users.SingleOrDefault(x=>x.Email==email);
            if (alici == null)
            {
                ViewBag.hata = "Kayıtlarda böyle bir mail adresi yok";
                return View();
            }
            int id=alici.Id;
            string mail = User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value;

            var gonderenID=ctx.Users.SingleOrDefault(x=>x.Email==mail).Id;
            mu.AliciID=id;
            mu.GonderenID = gonderenID;
            mu.durum = true;
            mu.Tarih=Convert.ToDateTime( DateTime.Now.ToShortDateString());
            ctx.mesajUsers.Add(mu);
            ctx.SaveChanges();
            return RedirectToAction("Olustur");
        }

        public PartialViewResult SolMenu()
        {
            ViewBag.gelen=ctx.mesajUsers.Include(x=>x.Alici).Where(x=>x.Alici.UserName==User.Identity.Name).Count();
            ViewBag.giden=ctx.mesajUsers.Include(x=>x.Gonderen).Where(x=>x.Alici.UserName==User.Identity.Name).Count();
            

            return PartialView();
        }
        public IActionResult sil(string dizi)
        {
            int[] id=JsonConvert.DeserializeObject<int[]>(dizi);

            


            foreach (var item in id)
            {
                var mesaj = ctx.mesajUsers.SingleOrDefault(x => x.ID == item);
                ctx.mesajUsers.Remove(mesaj);
                ctx.SaveChanges();
            }
            return RedirectToAction("Giden");
        }
    }
}
