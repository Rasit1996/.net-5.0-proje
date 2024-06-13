using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents
{
    public class Istatistik2:ViewComponent
    {
        BContext ctx=new BContext();

        public  IViewComponentResult Invoke()
        {
            ViewBag.blog =  ctx.bloks.OrderByDescending(x => x.ID).Take(1).SingleOrDefault().Baslik;
            return View();
        }
    }
}
