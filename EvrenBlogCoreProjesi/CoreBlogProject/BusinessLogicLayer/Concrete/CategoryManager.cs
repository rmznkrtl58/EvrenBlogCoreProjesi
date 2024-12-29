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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }
        public Category GetCategoryById(int id)
        {
           return _categorydal.GetCategoryValueById(x => x.CategoryId == id);
        }
        public void TDelete(Category t)
        {
            _categorydal.DeleteRow(t);
        }
        public Category TGetById(int id)
        {
          return _categorydal.GetById(id);
        }

        public List<Category> TGetListAll()
        {
            return _categorydal.GetListAll(x=>x.CategoryStatus==true);
        }

        public List<Category> TGetListByCondition()
        {
            throw new NotImplementedException();
        }

        public Category TGetValueByCondition()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Category t)
        {
            _categorydal.InsertRow(t);
        }

        public void TUpdate(Category t)
        {
           _categorydal.UpdateRow(t);
        }
    }
}
