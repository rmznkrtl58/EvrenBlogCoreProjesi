using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.AreaWriter.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("AreaWriter")]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        private readonly UserManager<AppUser> _userManager;
        public BlogController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var finduser =await _userManager.FindByNameAsync(User.Identity.Name);
            var findid = finduser.Id;
            var myBlogs = bm.GetListMyBlog(findid);
            return View(myBlogs);
        }
        [HttpGet]
        public async Task<IActionResult> AddBlog() 
        {
            var finduser = await _userManager.FindByNameAsync(User.Identity.Name);
            var findid = finduser.Id;
            ViewBag.userId = findid;
           CategoryManager cm = new CategoryManager(new EfCategoryDal());
           List<SelectListItem> categorySelect = (from x in cm.TGetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }
                                                   ).ToList();
            ViewBag.comboboxC = categorySelect;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog b)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            var finduser = await _userManager.FindByNameAsync(User.Identity.Name);
            var findid = finduser.Id;
            b.AppUserId = findid;
            //var categoryId = cm.GetCategoryById(Convert.ToInt32(b.CategoryId));
            BlogValidator bv=new BlogValidator();
            ValidationResult validationResult=bv.Validate(b);
            if (validationResult.IsValid)
            {
                b.BlogStatus = true;
                b.BlogDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                //b.CategoryId = Convert.ToInt32(categoryId);
                bm.TInsert(b);
                return RedirectToAction("Index", "Blog");
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
        public IActionResult DeleteBlog(int id)
        {
            var findblog = bm.TGetById(id);
            findblog.BlogStatus= false;
            bm.TUpdate(findblog);
            return RedirectToAction("Index", "Blog");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categorySelect = (from x in cm.TGetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }
                                                   ).ToList();
            ViewBag.comboboxC = categorySelect;
            var values=bm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> EditBlog(Blog b)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var findId = findUser.Id;
            b.BlogStatus = true;
            b.BlogDate =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            b.AppUserId = findId;
            bm.TUpdate(b);
            return RedirectToAction("Index", "Blog");
        }
    }
}
