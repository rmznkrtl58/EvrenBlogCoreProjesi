using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Extensions;
using EntityLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
namespace CoreBlogProject.Controllers
{
   
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IActionResult Index(int page=1)
        {
            var values = cm.TGetListAll().ToPagedList(page,5);
            return View(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult validationResult = cv.Validate(c);
            if (validationResult.IsValid)
            {
                c.CategoryStatus = true;
                cm.TInsert(c);
                return RedirectToAction("Index", "Category");
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
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            var findCategory= cm.TGetById(id);
            findCategory.CategoryStatus = false;
            cm.TUpdate(findCategory);
            return RedirectToAction("Index","Category");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var findCategory = cm.TGetById(id);
            return View(findCategory);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditCategory(Category c)
        {
            c.CategoryStatus = true;
            cm.TUpdate(c);
            return RedirectToAction("Index","Category");
        }
    }
}
