using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
	public class HakkimizdaController : Controller
	{
		BContext ctx=new BContext();
		public IActionResult Index()
		{
			var model = ctx.hakkindas.FirstOrDefault();
			return View(model);
		}
	}
}
