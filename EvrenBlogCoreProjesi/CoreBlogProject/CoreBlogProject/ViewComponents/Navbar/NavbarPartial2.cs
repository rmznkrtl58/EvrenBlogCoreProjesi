using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.ViewComponents.Navbar
{
    public class NavbarPartial2:ViewComponent
    {
        AnnouncementManager1 abm=new AnnouncementManager1(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var values = abm.TGetListAll();
            ViewBag.c = abm.TGetListAll().Count;
            return View(values);
        }
    }
}
