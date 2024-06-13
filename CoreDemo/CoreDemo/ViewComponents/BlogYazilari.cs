using DataAccessLayer.Context;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
	public class BlogYazilari:ViewComponent
	{
		BContext ctx=new BContext();
		

		public async Task< IViewComponentResult> InvokeAsync(string? id)
		{

			List<Blok> blok;
			if (string.IsNullOrEmpty(id))
			{
				blok =await ctx.bloks.Include(x => x.kategori).Include(x => x.yorumcus).ToListAsync();
			}
			else
			{
				blok =await ctx.bloks.Include(x => x.kategori).Include(x => x.yorumcus).Where(x=>x.Baslik.Contains(id)).ToListAsync();	
			}
			return View(blok);
		}
	}
}
