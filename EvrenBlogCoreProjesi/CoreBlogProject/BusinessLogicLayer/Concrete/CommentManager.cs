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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public Comment GetCommentByIdWithBlog(int id)
        {
            return _commentdal.GetCommentById(x=>x.CommentId==id);
        }

        public List<Comment> GetListCommentByIdWithBlog(int id)
        {
           return _commentdal.GetListCommentById(x => x.BlogId == id&&x.DeleteStatus==true);
        }

        public List<Comment> GetListCommentWithBlog()
        {
            return _commentdal.GetListCommentAll(x => x.DeleteStatus == true);
        }

        public void TDelete(Comment t)
        {
            _commentdal.DeleteRow(t);
        }

        public Comment TGetById(int id)
        {
           return _commentdal.GetById(id);
        }

        public List<Comment> TGetListAll()
        {
          return _commentdal.GetListAll(x=>x.DeleteStatus==true);
        }

        public List<Comment> TGetListByCondition()
        {
            throw new NotImplementedException();
        }

        public Comment TGetValueByCondition()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Comment t)
        {
            _commentdal.InsertRow(t);
        }

        public void TUpdate(Comment t)
        {
            _commentdal.UpdateRow(t);
        }
    }
}
