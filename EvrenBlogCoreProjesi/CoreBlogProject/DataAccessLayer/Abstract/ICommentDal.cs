using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface ICommentDal:IGenericDal<Comment>
    {
        public List<Comment> GetListCommentById(Expression<Func<Comment,bool>>Filter); 
        public List<Comment> GetListCommentAll(Expression<Func<Comment,bool>>Filter); 
        public Comment GetCommentById(Expression<Func<Comment,bool>>Filter); 
    }
}
