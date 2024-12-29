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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void TDelete(About t)
        {
            _aboutdal.DeleteRow(t);
        }
        
        public About TGetById(int id)
        {
            return _aboutdal.GetById(id);
        }

        public List<About> TGetListAll()
        {
           return _aboutdal.GetListAll();
        }

        public List<About> TGetListByCondition()
        {
            throw new NotImplementedException();
        }

        public About TGetValueByCondition()
        {
            throw new NotImplementedException();
        }

        public void TInsert(About t)
        {
            _aboutdal.InsertRow(t);
        }

        public void TUpdate(About t)
        {
            _aboutdal.UpdateRow(t);
        }
    }
}
