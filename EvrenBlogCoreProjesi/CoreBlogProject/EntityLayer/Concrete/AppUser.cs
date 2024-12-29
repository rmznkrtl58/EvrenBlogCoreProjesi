using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string WriterDescription { get; set; }
        public string WriterStatus { get; set; }
        public string WriterImage { get; set; }
        public string WriterAddress { get; set; }
        //bir yazar bir den fazla blog yazar
        public List<Blog> Blogs { get; set; }
        //çoka çok ilişki 
        //alıcı yazar ve gönderen yazar birden fazla mesaj yazabilir
        public ICollection<Message> WriterSender { get; set; }
        public ICollection<Message> WriterReceiver { get; set; }

    }
}
