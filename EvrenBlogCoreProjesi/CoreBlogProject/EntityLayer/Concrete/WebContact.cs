using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WebContact
    {
        //KULLANICILARIN SİTEMİZLE ALAKALI ELEŞTİRİLERİNİ YOLLAYACAĞI BİR ALAN
        [Key]
        public int ContactId { get; set; }
        [StringLength(40)]
        public string NameSurname { get; set; }
        [StringLength(40)]
        public string Mail { get; set; }
        [StringLength(25)]
        public string Subject { get; set; }
        [StringLength(400)]
        public string ContactContent { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
