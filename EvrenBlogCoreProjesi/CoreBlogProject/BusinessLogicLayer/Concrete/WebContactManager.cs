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
    public class WebContactManager : IWebContactService
    {
        IWebContactDal _webcontactdal;

        public WebContactManager(IWebContactDal webcontactdal)
        {
            _webcontactdal = webcontactdal;
        }

        public void TDelete(WebContact t)
        {
            _webcontactdal.DeleteRow(t);
        }

        public WebContact TGetById(int id)
        {
            return _webcontactdal.GetById(id);
        }

        public List<WebContact> TGetListAll()
        {
            return _webcontactdal.GetListAll();
        }

        public List<WebContact> TGetListByCondition()
        {
            throw new NotImplementedException();
        }

        public WebContact TGetValueByCondition()
        {
            throw new NotImplementedException();
        }

        public void TInsert(WebContact t)
        {
            _webcontactdal.InsertRow(t);
        }

        public void TUpdate(WebContact t)
        {
            _webcontactdal.UpdateRow(t);
        }
    }
}
