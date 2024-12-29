using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommunicationController : Controller
    {
        CommunicationManager cm = new CommunicationManager(new EfCommunicationDal());
        [HttpGet]
        public IActionResult Index(int id)
        {
            var findcommunication = cm.TGetById(1);
            return View(findcommunication);
        }
        [HttpPost]
        public IActionResult Index(Communication c)
        {
            cm.TUpdate(c);
            return View(c);
        }
    }
}
