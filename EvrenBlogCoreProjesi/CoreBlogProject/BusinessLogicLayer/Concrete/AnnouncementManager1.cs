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

    public class AnnouncementManager1 : IAnnoucementService
    {
        IAnnouncementDal _announcementDal;
        public AnnouncementManager1(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }
        public void TDelete(Announcement t)
        {
            _announcementDal.DeleteRow(t);
        }

        public Announcement TGetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Announcement> TGetListAll()
        {
            return _announcementDal.GetListAll();
        }

        public List<Announcement> TGetListByCondition()
        {
            throw new NotImplementedException();
        }

        public Announcement TGetValueByCondition()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Announcement t)
        {
            _announcementDal.InsertRow(t);
        }

        public void TUpdate(Announcement t)
        {
            _announcementDal.UpdateRow(t);
        }
    }
}
