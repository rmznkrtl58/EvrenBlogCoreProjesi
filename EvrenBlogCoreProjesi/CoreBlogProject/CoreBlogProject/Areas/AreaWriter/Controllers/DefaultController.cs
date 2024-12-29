using CoreBlogProject.Areas.AreaWriter.Models;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.AreaWriter.Controllers
{   //Yazar bilgilerini getirip güncelleme
    //1->UserManager Constructor metod oluştur
    //2->UserUpdateViewModel oluştur not:area içerisindeki modelde
    //3->gerekli işlemleri yaparsın 
    //[Authorize(Roles = "Admin")]
    [Area("AreaWriter")]
    public class DefaultController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        public DefaultController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _userManager= userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {   //sisteme authentice olan kullanıcının bilgilerini getirme
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userModel = new UserUpdateViewModel()
            {
                mail = values.Email,
                nameSurname = values.NameSurname,
                userSurname=values.UserName,
                writerDescription=values.WriterDescription,
                writerStatus=values.WriterStatus,
                //writerImageUrl=values.WriterImage,
                writerAddress=values.WriterAddress
            };
            return View(userModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserUpdateViewModel userModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = userModel.nameSurname;
            values.UserName = userModel.userSurname;
            values.Email = userModel.mail;
            values.WriterDescription= userModel.writerDescription;
            values.WriterStatus= userModel.writerStatus;
            //Resim Güncelleme 
            //1->View tarafında formun enctype="multipart/form-data" olacak
            //2->input type file ve name="UserUpdateViewModel deki ImageUrl Propu olacak"
            //3->Modelimin içerisindeki image propumu IFormFile yap
            //4->wwwroot içerisine resimlerimin olacağı bir klasör oluştur
            if (userModel.writerImageUrl != null)//resim seçiliyse
            {
                var extension = Path.GetExtension(userModel.writerImageUrl.FileName);
                //uzantı=seçili olan resmimin isim değeri
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/UserImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                //dosyamın akışı location'daki konuma ve modu oluşturma modunda olacak
                userModel.writerImageUrl.CopyTo(stream);
                values.WriterImage = newImageName;
                //veritabanınada newImageName'den gelen dizini string olarak kaydedecek
            }
            values.WriterAddress= userModel.writerAddress;
            if (!string.IsNullOrEmpty(userModel.password))//string değeri boş değilse
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userModel.password);
                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login", new { area = "" });
                }
                else
                {
                    return View();
                }
            }
            else
            {
                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login", new { area = "" });
                }
                else
                {
                    return View();
                }
            }
           
        }
    }
}
