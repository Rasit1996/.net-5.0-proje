using CoreDemo.Models;
using DataAccessLayer.Context;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class GirisController : Controller
	{
		BContext ctx=new BContext();
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;


		public GirisController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
			_userManager = userManager;
		}

		

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(SubInUser sub)
		{
			
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(sub.Email);
				if (user == null)
				{
					return View(sub);
				}
				var result = await _signInManager.PasswordSignInAsync(user.UserName, sub.Sifre, false, true);
				if (result.Succeeded)
				{
					//await _signInManager.SignInAsync(user, false);
					var isim = User.Identity.Name;
					return RedirectToAction("Index", "Blok");
				}
				else if (result.IsLockedOut)
				{
					ModelState.AddModelError("", "Kullanıcı hesabı kilitlenmiş");
				}
				else
				{
					ModelState.AddModelError("", "Yanlış şifre veya kullanıcı adı");
				}
			}
			return View(sub);
		}


		//public async Task< IActionResult > Index(Yazar y)
		//{
		//	var yazar=await ctx.yazars.SingleOrDefaultAsync(x=>x.Mail==y.Mail&&x.Sifre==y.Sifre);
		//	if (yazar!=null)
		//	{
		//		var claims = new List<Claim>()
		//		{
		//			new Claim(ClaimTypes.Name,yazar.Adi),
		//		   new Claim(ClaimTypes.Email, y.Mail)
		//		};

		//	var claimIdentitys = new ClaimsIdentity(claims, "Login");
		//		var principal=new ClaimsPrincipal(claimIdentitys);
		//		await HttpContext.SignInAsync(principal);
		//		var a = principal.Identities.SingleOrDefault(x => x.AuthenticationType == "Login");
		//		var b = claimIdentitys.Claims.SingleOrDefault(x => x.Value ==yazar.Mail);
		//		return RedirectToAction("Index","Blok");
		//	}
		//	ViewBag.hata = "Yanlış kullanıcı adı veya şifre";
		//	return View();

		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task< IActionResult > Cikis()
		{
			
			 await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}

		public IActionResult SifremiUnuttum()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SifremiUnuttum(SubIChangePasswordUser u) 
		{
			if (ModelState.IsValid)
			{
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == u.Email);
                if (user == null)
                {
                    ViewBag.hata = "Lütfen sistemde kayıtlı olan bir mail adresi giriniz.";
                    return View(u);
                }
                if (u.Sifre != u.SifreTekrar)
				{
					ViewBag.hata = "Şifreler uyuşmuyor";
					return View(u);
				}
				try
				{
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, u.Sifre);
					var result=await _userManager.UpdateAsync(user);
					if (!result.Succeeded) 
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError("",$"code={item.Code} mesaj={item.Description}");
						}
					}
					ViewBag.success = "başarılı";
					return View(u);
                }
				catch (System.Exception)
				{

					
				}

               

            }
            
                              
            return View(u);
        }
	}
}
