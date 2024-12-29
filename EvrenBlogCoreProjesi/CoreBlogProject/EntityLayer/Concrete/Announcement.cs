using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
    }
}
