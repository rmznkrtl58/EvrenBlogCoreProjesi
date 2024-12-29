using CoreBlogProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    //Identity ile kayıt olma 
    //1.)UserRegisterViewModel oluşturuyoz.
    //2.)UserManager'e bağlı bir constructor metod oluştur.
    //3.)gereken işlemler aşağıda
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        public RegisterController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegister)
        {
            if (ModelState.IsValid)
            {
                AppUser _appUser = new AppUser()
                {
                    NameSurname = userRegister.nameSurname,
                    UserName = userRegister.userName,
                    Email = userRegister.mail,
                    WriterDescription = userRegister.writerDescription,
                    WriterStatus= userRegister.writerStatus,
                    WriterImage=userRegister.writerImageUrl,
                    WriterAddress=userRegister.writerAddress,
                };
                var result = await _userManager.CreateAsync(_appUser, userRegister.writerPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach(var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }
                }
            }
            return View(userRegister);
        }
    }
}
