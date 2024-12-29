using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject
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
            services.AddControllersWithViews();
        

        //------------------------------------------------------------------------    

            //Identity i�in gerekli �eyler a�a��dad�r
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                //x.Password.RequiredUniqueChars = 4;
                //ASP.NET Core Identity framework'�nde
                //bir parolan�n i�ermesi gereken benzersiz
                //karakter say�s�n� belirtir.
                x.Password.RequireUppercase = false;
                //zorunlu bir b�y�k harf olmas�n� kald�r�r
                x.Password.RequireNonAlphanumeric= false;
                // bir parolan�n en az bir alfanumerik olmayan
                // karakter (�rne�in !, @, #, %) i�ermesini gerektirip
                // gerektirmedi�ini belirler.false oldu�u i�in gerektirmez
                //x.Password.RequireDigit= false;
                //bir parolan�n en az bir rakam (digit)
                //i�ermesi gerekip gerekmedi�ini belirler false oldu�u i�in
                //gerektirmez
            }).AddEntityFrameworkStores<Context>();

            //------------------------------------------------------------------------    



            //------------------------------------------------------------------------    
            //SESS�ON ��LEMLER�N� KULLANMAM ���N
            services.AddSession();

            // Proje seviyesi AUTHOR�ZE ��LEM� ���N
            //bunlar� yapt�ktan sonra configure metodununun i�ersiine gerekli �eyi yaz
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //Authontice olmayan kullan�c� nereye y�nlenecek
            services.AddMvc();
            services.AddAuthentication(
               CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index/";
                });
            //------------------------------------------------------------------------


            //------------------------------------------------------------------------

            //Maalesef program a�a��ya getirceklerimi default
            //getirmedi�inden buraya yap��t�raca��m
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                //sisteme rollemede yetkilendirilmi� ki�i harici girdi�i an ��kaca�� hata sayfas�n�n yolu
                options.AccessDeniedPath = new PathString("/ErrorPages/AccessDenied/");
                options.LoginPath = "/Login/Index/";
                options.SlidingExpiration = true;
            });

            //------------------------------------------------------------------------
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Hata Sayfalar� ��in
            app.UseStatusCodePagesWithReExecute("/ErrorPages/Index/", "?code={0}");

            //AUTHONT�CE ��LEM� ���N 
            app.UseAuthentication();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               //arealar�n �al��mas� i�in a�a��dakilerin olmas� laz�m
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Login}/{action=Index}/{id?}");
               
                endpoints.MapDefaultControllerRoute();
               
            });
        }
    }
}
