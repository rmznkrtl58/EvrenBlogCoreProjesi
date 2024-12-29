using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public Message GetMessageById(Expression<Func<Message, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Messages.Include(x => x.SenderUser).Where(Filter).FirstOrDefault();
            }
        }

        public List<Message> GetMessageListByReceiver(Expression<Func<Message, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Messages.Where(Filter).Include(x => x.SenderUser).ToList();
            }
        }

        public List<Message> GetMessageListBySender(Expression<Func<Message, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Messages.Where(Filter).Include(x => x.ReceiverUser).ToList();
            }
        }
    }
}
