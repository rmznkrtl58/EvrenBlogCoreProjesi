using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IMessageDal:IGenericDal<Message>
    {
        public List<Message> GetMessageListByReceiver(Expression<Func<Message,bool>>Filter);
        public List<Message> GetMessageListBySender(Expression<Func<Message,bool>>Filter);
        public Message GetMessageById(Expression<Func<Message,bool>>Filter);
    }
}
