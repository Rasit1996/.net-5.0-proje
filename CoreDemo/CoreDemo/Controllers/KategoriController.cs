using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class KategoriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
