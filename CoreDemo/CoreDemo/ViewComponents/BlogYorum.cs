using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
	public class BlogYorum:ViewComponent
	{
		BContext ctx=new BContext();
		public async Task<IViewComponentResult> InvokeAsync(int id = 0)
		{
			var y = await ctx.yorumcus.Where(x => x.BlokID == id).ToListAsync();
			return View(y);
		}
	}
}
