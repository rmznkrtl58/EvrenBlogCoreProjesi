using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key] 
        public int BlogId { get; set; }
        [StringLength(150)]
        public string BlogTitle { get; set; }
        [StringLength(300)]
        public string BlogImage{ get; set; }
        public string BlogContent{ get; set; }
        public DateTime BlogDate{ get; set; }
        public bool BlogStatus { get; set; }

        //bir blog sadece bir kategoriye aittir 
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        //bir blogu sadece bir yazar yazabilir(AppUser(Identity))
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
