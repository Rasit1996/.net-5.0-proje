using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class DashBoardBlog:ViewComponent
    {
        BContext ctx=new BContext();
        public async Task< IViewComponentResult > InvokeAsync()
        {
            
            var blogs=await ctx.bloks.Include(x=>x.kategori).Where(x=>x.User.UserName==User.Identity.Name).ToListAsync();
            return View(blogs);
        }
    }
}
