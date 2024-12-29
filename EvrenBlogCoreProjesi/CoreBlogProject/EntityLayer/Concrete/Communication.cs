using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Communication
    {
        //SİTENİN İLETİŞİM ADRESİ
        [Key]
        public int CommunicationId { get; set; }
        [StringLength(70)]
        public string Address { get; set; }
        [StringLength(20)] 
        public string Phone { get; set; }
        [StringLength(40)]
        public string Mail { get; set; }
    }
}
