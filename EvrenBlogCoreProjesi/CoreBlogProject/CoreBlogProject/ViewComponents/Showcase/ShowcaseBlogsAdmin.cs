using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlogProject.ViewComponents.Showcase
{   
    public class ShowcaseBlogsAdmin:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public ShowcaseBlogsAdmin(UserManager<AppUser> userManager)
        {
            _userManager= userManager;
        }
        WriterManager wm = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke()
        {
            var findAdmin = _userManager.Users.FirstOrDefault(x => x.Id == 4);
            ViewBag.a = findAdmin.NameSurname;
            ViewBag.a2 = findAdmin.WriterDescription;
            ViewBag.a3 = findAdmin.WriterStatus;
            ViewBag.a4 = findAdmin.WriterImage;
            return View();
        }
    }
}
