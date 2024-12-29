using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Sidebar
{
    public class SidebarNameArea:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public SidebarNameArea(UserManager<AppUser> userManager)
        {
            _userManager= userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ns = findUser.NameSurname;
            ViewBag.wi = findUser.WriterImage;
            return View();
        }
    }
}
