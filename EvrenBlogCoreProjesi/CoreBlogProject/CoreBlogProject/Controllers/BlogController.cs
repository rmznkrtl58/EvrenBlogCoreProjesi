using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Extensions;

namespace CoreBlogProject.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        private readonly UserManager<AppUser> _userManager;
        public BlogController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index(int page=1)
        {
            var values = bm.GetListBlogWithCategoryAndWriter().ToPagedList(page,5);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBlog()
        { 
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            var userList = _userManager.Users.ToList();
            List<SelectListItem> cd = (from x in cm.TGetListAll()
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value = x.CategoryId.ToString()
                                       }
                                    ).ToList();
            List<SelectListItem> cu = (from x in userList
                                       select new SelectListItem
                                       {
                                           Text = x.NameSurname,
                                           Value = x.Id.ToString()
                                       }
                                    ).ToList();
            ViewBag.comboboxC= cd;
            ViewBag.comboboxU = cu;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog b)
        {
            CategoryManager cm=new CategoryManager(new EfCategoryDal());
            BlogValidator bv=new BlogValidator();
            ValidationResult validationResult = bv.Validate(b);
            if (validationResult.IsValid)
            {
                b.BlogDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                b.BlogStatus = true;
                bm.TInsert(b);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach(var x in validationResult.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteBlog(int id)
        {
            var findblog=bm.TGetById(id);
            findblog.BlogStatus= false;
            bm.TUpdate(findblog);
            return RedirectToAction("Index","Blog");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var userList = _userManager.Users.ToList();
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> dc = (from x in cm.TGetListAll()
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value = x.CategoryId.ToString()
                                       }
                                    ).ToList();
            List<SelectListItem> cu = (from x in userList
                                       select new SelectListItem
                                       {
                                           Text = x.NameSurname,
                                           Value = x.Id.ToString()
                                       }
                                  ).ToList();
            ViewBag.comboboxU = cu;
            ViewBag.c = dc;
            var findblog = bm.TGetById(id);
            return View(findblog);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            b.BlogStatus = true;
            b.BlogDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            bm.TUpdate(b);
            return RedirectToAction("Index","Blog");
        }
    }
}
