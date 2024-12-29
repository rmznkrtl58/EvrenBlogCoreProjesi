using System.ComponentModel.DataAnnotations;

namespace CoreBlogProject.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen Role İsmini Giriniz")]
        public string roleName { get; set; }
    }
}
