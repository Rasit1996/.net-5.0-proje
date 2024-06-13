using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult Index(int code)
		{

			return View();
		}
	}
}
