using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public String CategoryName { get; set; }
        //bir kategoride birden fazla blog olabilir
        public bool CategoryStatus { get; set; }

        public List<Blog> Blogs { get; set; }

    }
}
