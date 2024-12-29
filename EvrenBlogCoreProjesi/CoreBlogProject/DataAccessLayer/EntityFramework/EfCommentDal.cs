using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public Comment GetCommentById(Expression<Func<Comment, bool>> Filter)
        {
            using (var ent = new Context())
            {
                return ent.Comments.Include(x => x.Blog).Where(Filter).FirstOrDefault();
            }
        }

        public List<Comment> GetListCommentAll(Expression<Func<Comment, bool>> Filter)
        {
            using (var ent = new Context())
            {
                return ent.Comments.Include(x => x.Blog).Where(Filter).ToList();
            }
        }
        public List<Comment> GetListCommentById(Expression<Func<Comment, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Comments.Include(x => x.Blog).Where(Filter).ToList();
            }
        }
    }
}
