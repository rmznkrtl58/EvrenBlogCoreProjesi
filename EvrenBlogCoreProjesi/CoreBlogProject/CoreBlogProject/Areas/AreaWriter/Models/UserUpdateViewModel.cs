using Microsoft.AspNetCore.Http;//IFormFile için

namespace CoreBlogProject.Areas.AreaWriter.Models
{
    public class UserUpdateViewModel
    {
        public string nameSurname { get; set; }
        public string userSurname { get; set; }
        public string mail { get; set; }
        public string writerDescription { get; set; }
        public string writerStatus { get; set; }
        public IFormFile writerImageUrl { get; set; }
        //mutlaka IFormFile olmalı
        public string writerAddress { get; set; }
        public string password { get; set; }
    }
}
