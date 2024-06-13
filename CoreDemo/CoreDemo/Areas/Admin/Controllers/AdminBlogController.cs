using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BContext ctx=new BContext();
        public IActionResult Index()
        {
            var bloglar = ctx.bloks.Include(x => x.kategori).ToList();

            return View(bloglar);
        }
    }
}
