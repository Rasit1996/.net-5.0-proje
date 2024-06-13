using CoreDemo.Models;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class IdentityKayitController : Controller
    {
        
        private readonly UserManager<AppUser> _UserManager;
        public IdentityKayitController(UserManager<AppUser> userManager)
        {
            _UserManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Index(SubIdentityUser SIU,string kabul)
        {
            if (kabul =="on")
            {
                if (ModelState.IsValid)
                {
                    AppUser user = new AppUser()
                    {
                        Email = SIU.Email,
                        UserName = SIU.Adi,
                        SurName = SIU.Soyadi,

                    };
                    IdentityResult result = await _UserManager.CreateAsync(user, SIU.Sifre);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Blok");
                    }

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }

                }
            }
            else
            {
                ViewBag.hata = "Şartı kabul ediniz!";
            }
            return View();
        }
    }
}
