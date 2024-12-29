namespace CoreBlogProject.Models
{
    public class UserAssingRoleViewModel
    {
        //AspNetUserRoles Tablosu için aslında 
        public int roleId { get; set; }
        public string roleName { get; set; }
        public bool exists { get; set; }//seçili gelmesi için kullandığım prop
    }
}
