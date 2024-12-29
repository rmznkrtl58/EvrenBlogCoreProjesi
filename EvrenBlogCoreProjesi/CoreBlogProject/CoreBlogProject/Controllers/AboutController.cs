using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        
        AboutManager abm = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            var findabout = abm.TGetById(6);
            return View(findabout);
        }
        [HttpPost]
        public IActionResult Index(About a)
        {
            abm.TUpdate(a);
            return View(a);
        }
    }
}
