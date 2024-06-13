using EntityLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _usermanager;
		private readonly SignInManager<AppUser> _signinmanager;

        public UserController(UserManager<AppUser> usermanager, SignInManager<AppUser> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }

        public async Task<IActionResult> ProfilGuncelle()
		{
			var yazar =await _usermanager.FindByNameAsync(User.Identity.Name); 
			return View(yazar);
		}

		[HttpPost]

		public async Task<IActionResult> ProfilGuncelle(AppUser user, IFormFile Image,string Sifre,string SifreTekrar,string checkbox)
		{
			
			if (Sifre==SifreTekrar)
			{
                var u = await _usermanager.FindByNameAsync(User.Identity.Name);
                string name = u.UserName;
                u.SurName = user.SurName;
                u.Email = user.Email;
                u.UserName = user.UserName;
                u.Hakkinda = user.Hakkinda;
                if (checkbox=="on")
                {
                    u.PasswordHash = _usermanager.PasswordHasher.HashPassword(u, Sifre);
                }
                if (Image != null)
                {
                    string yol = "/CoreBlogTema/Resimler/" + Guid.NewGuid() + Path.GetExtension(Image.FileName);
                    string dosya = "wwwroot" + yol;
                    var stream = new FileStream(dosya, FileMode.Create);
                    Image.CopyTo(stream);
                    u.ImageUrl = yol;
                }
                var result = await _usermanager.UpdateAsync(u);
                if (!result.Succeeded)
                {

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                    return View(user);
                }
                if (u.UserName != name)
                {
                    await _signinmanager.SignOutAsync();
                }


                return RedirectToAction("Profilim", "Yazar");
            }
           
                ViewBag.Sifre = "Şifreler uyuşmuyor";
            var us = await _usermanager.FindByNameAsync(User.Identity.Name);
            return View(us);
            
                
			
		}
	}
}
