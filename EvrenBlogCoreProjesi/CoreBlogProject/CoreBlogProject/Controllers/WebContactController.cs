using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Controllers
{   
    public class WebContactController : Controller
    {
        WebContactManager cm = new WebContactManager(new EfWebContactDal());
        public IActionResult Index()
        {
            var values = cm.TGetListAll();
            return View(values);
        }
    }
}
