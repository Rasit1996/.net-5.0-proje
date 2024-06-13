using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfilController : Controller
    {
        BContext ctx=new BContext();
        public IActionResult Index()
        {
            var user=ctx.Users.SingleOrDefault(x=>x.UserName==User.Identity.Name);
            return View(user);
        }
    }
}
