using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreBlogProject.Areas.Showcase.Controllers
{   
    [Area("Showcase")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        WebContactManager cm = new WebContactManager(new EfWebContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.t = "İletişim";
            ViewBag.t2 = "Girizgah";
            ViewBag.t3 = "İletişim";
            return View();
        }
        [HttpPost]
        public IActionResult Index(WebContact c)
        {
            ContactValidator cv = new ContactValidator();
            ValidationResult validationResult=cv.Validate(c);
            if (validationResult.IsValid)
            {
                c.ContactDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                cm.TInsert(c);
                return RedirectToAction("Index", "Default", new {area="Showcase"});
            }
            else
            {
                foreach(var x in validationResult.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                return View();
            }
           
        }
    }
}
