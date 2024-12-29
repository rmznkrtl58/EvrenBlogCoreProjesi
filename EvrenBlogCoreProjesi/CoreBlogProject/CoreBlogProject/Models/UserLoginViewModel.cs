using System.ComponentModel.DataAnnotations;

namespace CoreBlogProject.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz.")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string password { get; set; }
    }
}
