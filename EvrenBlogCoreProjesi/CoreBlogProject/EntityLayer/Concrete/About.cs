using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        [StringLength(100)]
        public string AboutTitle { get; set; }
        [StringLength(500)]
        public string AboutSubTitle { get; set; }
        [StringLength(500)]
        public string item1 { get; set; }
        [StringLength(300)]
        public string item2 { get; set; }
        [StringLength(300)]
        public string item3 { get; set; }
        [StringLength(300)]
        public string item4 { get; set; }
        [StringLength(300)]
        public string item5 { get; set; }
        [StringLength(300)]
        public string BlogImg1 { get; set; }
        [StringLength(300)]
        public string BlogImg2 { get; set; }
        [StringLength(300)]
        public string BlogImg3 { get; set; }
    }
}
