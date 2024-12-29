using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>where T : class
    {
        public List<T> GetListAll();
        public List<T> GetListAll(Expression<Func<T,bool>>filter);
        public T GetValue(Expression<Func<T,bool>>filter);
        public T GetById(int id);
        public void DeleteRow(T t);
        public void InsertRow(T t);
        public void UpdateRow(T t);
    }
}
