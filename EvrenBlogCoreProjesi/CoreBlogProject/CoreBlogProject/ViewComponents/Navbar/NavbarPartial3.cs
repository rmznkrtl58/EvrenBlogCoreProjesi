using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Navbar
{
    public class NavbarPartial3:ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        private readonly UserManager<AppUser> _userManager;
        public NavbarPartial3(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int userId = findUser.Id;
            var messageList= mm.GetMessageByReceiver(userId);
            return View(messageList);
        }
    }
}
