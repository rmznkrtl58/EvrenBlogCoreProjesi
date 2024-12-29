using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    [AllowAnonymous]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.t = "Hakkımızda";
            ViewBag.t2 = "Girizgah";
            ViewBag.t3 = "Hakkımızda";
            return View();
        }
    }
}
