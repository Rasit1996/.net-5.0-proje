using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminYorumController : Controller
    {
        BContext ctx=new BContext();
        public IActionResult Index()
        {
            
            var yorumlar=ctx.yorumcus.Include(x=>x.blok).ToList();  
            return View(yorumlar);
        }
    }
}
