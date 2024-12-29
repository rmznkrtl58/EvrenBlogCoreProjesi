using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        public List<T> TGetListAll();
        public List<T> TGetListByCondition();
        public T TGetById(int id);
        public T TGetValueByCondition();
        public void TInsert(T t);
        public void TUpdate(T t);
        public void TDelete(T t);
    }
}
