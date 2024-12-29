using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Controllers
{
    [AllowAnonymous]
    public class ErrorPagesController : Controller
    {
        public IActionResult Index(int code)//startupta oluşturduğum parametre ile aynı olmalı
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
