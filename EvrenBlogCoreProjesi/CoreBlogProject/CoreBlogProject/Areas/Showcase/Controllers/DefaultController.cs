using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.t = "Ana Sayfa";
            ViewBag.t2 = "Girizgah";
            ViewBag.t3 = "Ana Sayfa";
            return View();
        }
    }
}
