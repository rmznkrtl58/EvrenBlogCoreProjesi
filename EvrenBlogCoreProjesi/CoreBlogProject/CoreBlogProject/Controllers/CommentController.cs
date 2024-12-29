using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogProject.Controllers
{
    
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            var values = cm.GetListCommentWithBlog();
            return View(values);
        }
        public IActionResult EditComment(int id)
        {
            TempData["cmid"] = id;
            var values=cm.GetCommentByIdWithBlog(id);
            return View(values);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteComment()
        {
            var findValue=cm.TGetById((int)TempData["cmid"]);
            findValue.DeleteStatus = false;
            cm.TUpdate(findValue);
            return RedirectToAction("Index","Comment");
        }
    }
}
