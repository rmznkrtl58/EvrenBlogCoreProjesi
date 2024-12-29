using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.ViewComponents.Showcase
{
    public class ShowcaseContact1:ViewComponent
    {
        CommunicationManager cm = new CommunicationManager(new EfCommunicationDal());
        public IViewComponentResult Invoke()
        {
            var values = cm.TGetListAll();
            return View(values);
        }
    }
}
