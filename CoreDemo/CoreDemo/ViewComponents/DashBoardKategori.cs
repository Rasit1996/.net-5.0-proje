using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class DashBoardKategori:ViewComponent
    {
        BContext ctx=new BContext();
        public async Task< IViewComponentResult > InvokeAsync()
        {
            var kat = await ctx.kategoris.ToListAsync();
            return View(kat);
        }
    }
}
