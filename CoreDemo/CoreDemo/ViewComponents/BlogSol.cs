using DataAccessLayer.Context;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
	public class BlogSol:ViewComponent
	{ 
		BContext ctx=new BContext();
		public async Task<IViewComponentResult> InvokeAsync(int id = 0)
		{
			 var a= await ctx.bloks.Where(x => x.UserID == id).ToListAsync();
			ViewBag.ktg = await ctx.kategoris.ToListAsync();
			return View(a);
		}
	}
}
