using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashBoardController : Controller
    {
        BContext ctx=new BContext();
        public IActionResult Index()
        {
            ViewBag.top = ctx.bloks.ToList().Count;
            ViewBag.user=ctx.bloks.Where(x=>x.User.UserName==User.Identity.Name).ToList().Count;
            ViewBag.kat=ctx.kategoris.ToList().Count;
                
            return View();
        }
    }
}
