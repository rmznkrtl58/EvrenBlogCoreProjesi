using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.ViewComponents.Showcase
{
    public class ShowcaseBlogDetailsAdmin:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke(int id)
        {
            var value = bm.GetBlogById(id);
            ViewBag.img = value.AppUser.WriterImage;
            ViewBag.name = value.AppUser.NameSurname;
            ViewBag.description = value.AppUser.WriterDescription;
            ViewBag.status = value.AppUser.WriterStatus;
            return View();
        }
    }
}
