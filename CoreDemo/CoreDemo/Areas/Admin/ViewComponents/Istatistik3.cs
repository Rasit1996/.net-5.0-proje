using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents
{
    public class Istatistik3:ViewComponent
    {
        BContext ctx=new BContext();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var admin = await ctx.Users.SingleOrDefaultAsync(x => x.UserName==User.Identity.Name);
            return View(admin);
        }

    }
}
