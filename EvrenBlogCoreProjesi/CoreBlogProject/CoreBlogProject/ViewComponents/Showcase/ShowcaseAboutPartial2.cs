using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.ViewComponents.Showcase
{
    public class ShowcaseAboutPartial2:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke()
        {
            var values = wm.TGetListAll();
            return View(values);
        }
    }
}
