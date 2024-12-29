using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        public List<Comment> GetListCommentByIdWithBlog(int id);
        public List<Comment> GetListCommentWithBlog();
        public Comment GetCommentByIdWithBlog(int id);
    }
}
