using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> GetMessageByReceiver(int id);
        List<Message> GetMessageBySender(int id);
        public Message GetValueById(int id);
    }
}
