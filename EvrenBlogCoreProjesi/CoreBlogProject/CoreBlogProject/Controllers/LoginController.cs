using CoreBlogProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{   //Identity ile Giriş Yapma
    //1->UserLoginViewModel Oluştur.
    //2->SignInManager ile Constructor oluştur.
    //3->gerekli işlemleri yap
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signinmanager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signinmanager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userlogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinmanager.PasswordSignInAsync(userlogin.userName, userlogin.password, false, true);
                //1.p->kullanıcı adı 2.p->şifre 3.p->çerezler kabul edilsinmi
                //4.p->5 defa yanlış girildiğinde bir süre banlansınmı
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Default",new {area= "AreaWriter" });
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
