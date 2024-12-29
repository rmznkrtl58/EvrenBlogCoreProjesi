using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [StringLength(50)]
        public string NameSurname{ get; set; }
        [StringLength(50)]
        public string Mail{ get; set; }
        public DateTime CommentDate{ get; set; }
        [StringLength(150)]
        public string CommentContent{ get; set; }
        public bool DeleteStatus { get; set; }
        //Bir yorum bir bloga yapılabilir
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
