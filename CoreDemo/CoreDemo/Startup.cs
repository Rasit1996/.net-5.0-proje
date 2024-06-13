using CoreDemo.Models;
using DataAccessLayer.Context;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			//(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


			//services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
			//{
			//    x.LoginPath = "/Giris/Index";

			//});

			services.AddDbContext<BContext>();

			services.AddIdentity<AppUser, AppRoles>()
				.AddEntityFrameworkStores<BContext>()
				.AddDefaultTokenProviders().
				AddErrorDescriber<IdentityErrorMessage>();

			services.AddControllersWithViews();


            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));



            });

			services.ConfigureApplicationCookie(options =>
			{

				options.LoginPath = "/Giris/Index"; // Oturum a�ma sayfas�n�n URL'sini belirtin
				options.AccessDeniedPath = "/Admin/Account/AccessDenied"; // Eri�im reddedildi�inde y�nlendirilecek URL'yi belirtin (opsiyonel)
                                                                          // Di�er se�enekleri de burada yap�land�rabilirsiniz
              // Oturum s�resi yap�land�rmas�

                options.ExpireTimeSpan = TimeSpan.FromMinutes(10); // Oturum s�resini 1 dakika olarak ayarlay�n
                options.SlidingExpiration = true; // Oturum s�resinin isteklere ba�l� olarak uzat�lmas�n� sa�lar
                options.Cookie.HttpOnly = true; // �erezlerin sadece HTTP istekleriyle eri�ilebilir olmas�n� sa�lar (g�venlik i�in)
                options.Cookie.IsEssential = true; // GDPR ve di�er uyumluluklar i�in �erezi zorunlu k�lar
            });
      

			//services.AddAuthentication(options =>
			//{
			//    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			//    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			//    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			//})
			//.AddCookie(options =>
			//{
			//    options.LoginPath = "/Giris/Index"; 
			//});


			//services.AddRazorPages();





			//services.AddControllersWithViews();





			//services.AddDbContext<BContext>();
			//services.AddIdentity<AppUser, AppRoles>().AddEntityFrameworkStores<BContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			
			
			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
			
			app.UseStatusCodePagesWithReExecute("/Error/Index", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
			app.UseAuthentication();
			app.UseRouting();

			

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
          );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Yazarlar}/{action=Index}/{id?}");
            });
        }
    }
}
