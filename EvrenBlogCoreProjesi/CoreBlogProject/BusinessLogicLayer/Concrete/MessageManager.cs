using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetMessageByReceiver(int id)
        {
          return _messageDal.GetMessageListByReceiver(x => x.ReceiverId == id&&x.DeleteStatus==true);
        }

        public List<Message> GetMessageBySender(int id)
        {
            return _messageDal.GetMessageListBySender(x => x.SenderId == id && x.DeleteStatus == true);
        }

        public Message GetValueById(int id)
        {
            return _messageDal.GetMessageById(x => x.MessageId == id);
        }

        public void TDelete(Message t)
        {
            _messageDal.DeleteRow(t);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetListAll()
        {
          return _messageDal.GetListAll();
        }

        public List<Message> TGetListByCondition()
        {
            throw new NotImplementedException();
        }

        public Message TGetValueByCondition()
        {
            throw new NotImplementedException();
        }
        public void TInsert(Message t)
        {
           _messageDal.InsertRow(t);
        }

        public void TUpdate(Message t)
        {
            _messageDal.UpdateRow(t);
        }
    }
}
