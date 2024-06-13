using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Widgets : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
