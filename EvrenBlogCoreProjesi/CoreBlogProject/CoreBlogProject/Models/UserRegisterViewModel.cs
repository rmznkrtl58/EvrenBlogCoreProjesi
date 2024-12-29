using System.ComponentModel.DataAnnotations;

namespace CoreBlogProject.Models
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Adınızı Soyadınızı Girin")]
        public string nameSurname { get; set; }
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Girin")]
        public string userName { get; set; }
        [Display(Name ="E-posta")]
        [Required(ErrorMessage ="Lütfen Eposta Adresininiz Girin")]
        public string mail { get; set; }
        [Display(Name ="Yazar Açıklama")]
        [Required(ErrorMessage ="Lütfen Kendinize Ait Açıklama Yazınız")]
        public string writerDescription { get; set; }
        [Display(Name = "Yazar Meslek")]
        [Required(ErrorMessage = "Lütfen Kendinize Ait Mesleği Yazınız")]
        public string writerStatus { get; set; }
        [Display(Name = "Yazar Resim")]
        [Required(ErrorMessage = "Lütfen Kendinize Ait Resmi Giriniz")]
        public string writerImageUrl { get; set; }
        [Display(Name = "Yazar Adres")]
        [Required(ErrorMessage = "Lütfen Kendinize Ait Adresi Giriniz")]
        public string writerAddress { get; set; }
        [Display(Name = "Yazar Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string writerPassword { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("writerPassword", ErrorMessage ="Şifreler Uyuşmuyor")]
        public string confirmPassword { get; set; }
    }
}
