using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Controllers
{  
    public class AnnouncementController : Controller
    {
        AnnouncementManager1 abm = new AnnouncementManager1(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var values = abm.TGetListAll();
            return View(values);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult AddAnnouncemet()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddAnnouncemet(Announcement a)
        {
            AnnouncementValidator av=new AnnouncementValidator();
            ValidationResult validationResult= av.Validate(a);
            if (validationResult.IsValid)
            {
                abm.TInsert(a);
                return RedirectToAction("Index", "Announcement");
            }
            else
            {
                foreach(var x in validationResult.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAnnouncemet(int id)
        {
            var findValue=abm.TGetById(id);
            abm.TDelete(findValue);
            return RedirectToAction("Index","Announcement");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            var findValue=abm.TGetById(id);
            return View(findValue);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement a)
        {
            abm.TUpdate(a);
            return RedirectToAction("Index", "Announcement");
        }
        public IActionResult ContentAnnouncement(int id)
        {
            var findValue = abm.TGetById(id);
            return View(findValue);
        }
    }
}
