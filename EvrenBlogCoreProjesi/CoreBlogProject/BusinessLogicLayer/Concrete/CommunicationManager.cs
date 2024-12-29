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
    public class CommunicationManager : ICommunicationService
    {
        ICommunicationDal _communicationdal;

        public CommunicationManager(ICommunicationDal communicationdal)
        {
            _communicationdal = communicationdal;
        }

        public void TDelete(Communication t)
        {
            _communicationdal.DeleteRow(t);
        }

        public Communication TGetById(int id)
        {
            return _communicationdal.GetById(id);
        }

        public List<Communication> TGetListAll()
        {
            return _communicationdal.GetListAll();
        }

        public List<Communication> TGetListByCondition()
        {
            throw new NotImplementedException();
        }

        public Communication TGetValueByCondition()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Communication t)
        {
            _communicationdal.InsertRow(t);
        }

        public void TUpdate(Communication t)
        {
            _communicationdal.UpdateRow(t);
        }
    }
}
