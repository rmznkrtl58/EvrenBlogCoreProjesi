using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlogProject.ViewComponents.Showcase
{
    public class ShowcaseAboutPartial:ViewComponent
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = abm.TGetListAll();
            ViewBag.i1= abm.TGetListAll().Select(x=>x.BlogImg1).FirstOrDefault();
            ViewBag.i2= abm.TGetListAll().Select(x=>x.BlogImg2).FirstOrDefault();
            ViewBag.i3= abm.TGetListAll().Select(x=>x.BlogImg3).FirstOrDefault();
            return View(values);
        }
    }
}
