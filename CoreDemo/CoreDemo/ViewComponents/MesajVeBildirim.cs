using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class MesajVeBildirim:ViewComponent
    {
        BContext ctx=new BContext();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string alici=UserClaimsPrincipal.Claims.SingleOrDefault(x=>x.Type==ClaimTypes.Email).Value;
            ViewBag.bildirimler=await ctx.bildirims.Include(x=>x.user).Where(x=>x.user.UserName==User.Identity.Name&&x.Durum==true).ToListAsync();
            ViewBag.mesajlar=await ctx.mesajUsers.Include(x=>x.Gonderen).Where(x=>x.Alici.Email==alici).ToListAsync();
            ViewBag.count = await ctx.mesajUsers.Where(x => x.Alici.Email == alici).CountAsync();
            ViewBag.count2 = await ctx.bildirims.Include(x => x.user).Where(x => x.user.UserName == User.Identity.Name && x.Durum == true).CountAsync();
            return View();
        }
    }
}
