using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(40)]
        public string NameSurname { get; set; }
        [StringLength(40)]
        public string Mail { get; set; }
        [StringLength(200)]
        public string WriterDescription { get; set; }
        [StringLength(40)]
        public string WriterStatus { get; set; }
        [StringLength(300)]
        public string WriterImage { get; set; }
        [StringLength(20)]
        public string WriterPhone { get; set; }
        [StringLength(200)]
        public string WriterAddress { get; set; }
        public bool WriterDeleteStatus { get; set; }

    }
}
