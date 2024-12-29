using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Showcase.Controllers
{   [Area("Showcase")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        [HttpGet]
        public  PartialViewResult LeaveAComment()
        {
            
            return PartialView();
        }
        //public JsonResult LeaveComment()
        //{
        //    Comment c=new Comment();
        //    //c.BlogId = (int)TempData["bid"];
        //    ////blogdetails sayfamdaki tempdatayı kullandım
        //    //c.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    //c.DeleteStatus = true;
        //    //cm.TInsert(c);
        //    var values = JsonConvert.SerializeObject(c);
        //    return Json(values);
        //}
        [HttpPost]
        public PartialViewResult LeaveAComment(Comment c)
        {
            c.BlogId = (int)TempData["bid"];
            //blogdetails sayfamdaki tempdatayı kullandım
            c.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.DeleteStatus = true;
            cm.TInsert(c);
            var values = JsonConvert.SerializeObject(c);
            return PartialView();
        }
    }
}
