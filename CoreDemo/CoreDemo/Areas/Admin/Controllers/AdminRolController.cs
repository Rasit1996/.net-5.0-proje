using CoreDemo.Areas.Admin.Models;
using CoreDemo.Models;
using DataAccessLayer.Context;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminRolController : Controller
    {
        private readonly RoleManager<AppRoles> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AdminRolController(RoleManager<AppRoles> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var roller = _roleManager.Roles.ToList();
            return View(roller);
        }

        public IActionResult RolEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> RolEkle(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                AppRoles r=new AppRoles() { Name=model.name };
                var result=await _roleManager.CreateAsync(r);
                if(!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Guncelle(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id); 
            return View(role);

            
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(AppRoles role)
        {
            var rol=_roleManager.Roles.SingleOrDefault(x=>x.Id == role.Id);
            rol.Name = role.Name;
            var result=await _roleManager.UpdateAsync(rol);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Sil(int id)
        {
            var role=_roleManager.Roles.SingleOrDefault(x=>x.Id==id);
            var result=await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> usersRoles()
        {
            var user = await _userManager.Users.ToListAsync();
            return View(user);
        }

        public async Task<IActionResult> RolGuncelle(int id)
        {
            TempData["userID"] = id;
            var user=await _userManager.Users.SingleOrDefaultAsync(x=>x.Id==id);
            var roles=await _roleManager.Roles.ToListAsync();
            var userroles=await _userManager.GetRolesAsync(user);
             
            List<RoleIslemi> model=new List<RoleIslemi>();
            foreach (var role in roles)
            {
                RoleIslemi m=new RoleIslemi();
                m.RoleID=role.Id;
                m.name=role.Name;
                m.durum = userroles.Contains(role.Name);
                model.Add(m);
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> RolGuncelle(List<RoleIslemi> model)
        {
            int id = (int)TempData["userID"];
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id);
            foreach (var role in model)
            {
                if (role.durum)
                {
                  var result=  await _userManager.AddToRoleAsync(user, role.name);
                    if (!result.Succeeded)
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("" ,$"code: {item.Code} mesaj: {item.Description}");
                        }
                        return View(model);
                    }
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.name);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Cikis()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
