using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using CoreBlogProject.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var writers =_userManager.Users.ToList();
            return View(writers);
        }
        public  IActionResult Writerİnfo(int id)
        {
            var findWriter = _userManager.Users.FirstOrDefault(x => x.Id == id);
            return View(findWriter);
        }
        public async Task<IActionResult> DeleteWriter(int id)
        {
            var findWriter = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var result =await _userManager.DeleteAsync(findWriter);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }
       
    }
}
