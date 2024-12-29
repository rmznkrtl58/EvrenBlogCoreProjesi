using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Areas.Showcase.Controllers
{
    [Area("Showcase")]
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {
            ViewBag.t = "Bloglar";
            ViewBag.t2 = "Girizgah";
            ViewBag.t3 = "Bloglar";
          
            var values = bm.GetListBlogWithCategoryAndWriter();
            return View(values);
        }
        public IActionResult BlogDetails(int id)
        {
            var value = bm.GetBlogById(id);
            ViewBag.t = "Blog";
            ViewBag.t2 = value.BlogTitle;
            ViewBag.t3 = "Blog";
            ViewBag.id = value.BlogId;
            TempData["bid"] = value.BlogId;
            //BlogDetails sayfama tempdata vasıtasıyla blogidsini taşıdım
            //yorum yapmam için gerekliydi:)
            return View(value);
        }
    }
}
