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

            //Identity için gerekli þeyler aþaðýdadýr
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                //x.Password.RequiredUniqueChars = 4;
                //ASP.NET Core Identity framework'ünde
                //bir parolanýn içermesi gereken benzersiz
                //karakter sayýsýný belirtir.
                x.Password.RequireUppercase = false;
                //zorunlu bir büyük harf olmasýný kaldýrýr
                x.Password.RequireNonAlphanumeric= false;
                // bir parolanýn en az bir alfanumerik olmayan
                // karakter (örneðin !, @, #, %) içermesini gerektirip
                // gerektirmediðini belirler.false olduðu için gerektirmez
                //x.Password.RequireDigit= false;
                //bir parolanýn en az bir rakam (digit)
                //içermesi gerekip gerekmediðini belirler false olduðu için
                //gerektirmez
            }).AddEntityFrameworkStores<Context>();

            //------------------------------------------------------------------------    



            //------------------------------------------------------------------------    
            //SESSÝON ÝÞLEMLERÝNÝ KULLANMAM ÝÇÝN
            services.AddSession();

            // Proje seviyesi AUTHORÝZE ÝÞLEMÝ ÝÇÝN
            //bunlarý yaptýktan sonra configure metodununun içersiine gerekli þeyi yaz
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //Authontice olmayan kullanýcý nereye yönlenecek
            services.AddMvc();
            services.AddAuthentication(
               CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index/";
                });
            //------------------------------------------------------------------------


            //------------------------------------------------------------------------

            //Maalesef program aþaðýya getirceklerimi default
            //getirmediðinden buraya yapýþtýracaðým
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                //sisteme rollemede yetkilendirilmiþ kiþi harici girdiði an çýkacaðý hata sayfasýnýn yolu
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

            //Hata Sayfalarý Ýçin
            app.UseStatusCodePagesWithReExecute("/ErrorPages/Index/", "?code={0}");

            //AUTHONTÝCE ÝÞLEMÝ ÝÇÝN 
            app.UseAuthentication();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               //arealarýn çalýþmasý için aþaðýdakilerin olmasý lazým
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
