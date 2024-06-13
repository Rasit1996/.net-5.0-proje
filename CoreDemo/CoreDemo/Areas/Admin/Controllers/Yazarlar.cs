using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Yazarlar : Controller
    {
        BContext ctx=new BContext();
        public IActionResult Index()
        {
            ViewBag.adet = 0;
            return View();
        }

        [HttpGet]
        public PartialViewResult yazarlar()
        {
            ViewBag.liste = ctx.yazars.ToList();
            return PartialView();
        }
        [HttpPost]
        public IActionResult Sil(int id)
        {
            ctx.yazars.Remove(ctx.yazars.SingleOrDefault(x=>x.ID == id));
            ctx.SaveChanges();
            return Ok();
        }
    }
}
