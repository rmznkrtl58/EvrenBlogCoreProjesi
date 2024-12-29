using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=CoreBlogProject;integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //çoka çok ilişki kurmak
            //Hasone:Message tablosu ile SenderUser arasında
            //bire-çok veya çoka-çok ilişki olduğunu belirtir.
            //Message modelinde bir SenderUser (gönderici kullanıcı) olduğu,
            //yani Message tablosunun bir SenderUser ile ilişkili olduğunu ifade eder.
            //withmany:bir kullanıcı birden fazla mesaj gönderebilir,
            //bu yüzden WriterSender olarak bir koleksiyon tanımlanmış olabilir.
            //hasforeignkey:Burada SenderId adlı bir sütun, AppUser tablosunun
            //birincil anahtarına (primary key) bağlanır.
            //Yani,her bir mesajın bir göndereni (SenderUser) olur.
            //ondelete(deletebehavior.clientsetnull):Eğer SenderUser silinirse,
            //Message tablosundaki SenderId sütunu NULL yapılır.
            //Yani, mesaj kaydı silinmez, sadece gönderen kullanıcı ile ilişkisi kesilir.
            //genel sonuç: bir mesajın (Message) bir gönderen kullanıcıya (SenderUser) ait olduğunu ve
            //her kullanıcının birden fazla mesaj gönderebileceğini belirtir.
            //Ayrıca, gönderici kullanıcı silindiğinde mesaj kaydının korunmasını sağlar
            //ve sadece ilişkisi NULL yapılır.
            builder.Entity<Message>()
                .HasOne(x=>x.SenderUser)
                .WithMany(x=>x.WriterSender)
                .HasForeignKey(x=>x.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //yukardaki tanımlamalar aynen geçerli burdada alıcı kullanıcının mesaj atabileceğini
            //belirtiyoruz
            builder.Entity<Message>()
               .HasOne(x => x.ReceiverUser)
               .WithMany(x => x.WriterReceiver)
               .HasForeignKey(x => x.ReceiverId)
               .OnDelete(DeleteBehavior.ClientSetNull);
            //HasKey Id'nin hangisi olduğunu belirtir
            builder.Entity<AppUser>().HasKey(x => x.Id);
            //Identityde hata olmasın diye oluşturdum
            base.OnModelCreating(builder);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog>Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<WebContact> WebContacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
