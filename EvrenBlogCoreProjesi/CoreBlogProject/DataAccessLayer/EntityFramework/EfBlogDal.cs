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
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListBlogWithCategory(Expression<Func<Blog, bool>> Filter)
        {
            using (var ent = new Context())
            {
                return ent.Blogs.Include(x => x.Category).Include(y => y.AppUser).Where(Filter).ToList();
            };
        }

        public List<Blog> GetListBlogWithUser(Expression<Func<Blog, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Blogs.Include(x=>x.AppUser).Include(x=>x.Category).Where(Filter).ToList();
            }
        }
        public List<Blog> GetListLastOneBlog(Expression<Func<Blog, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Blogs.Include(x=>x.Category).Include(x=>x.AppUser).OrderByDescending(x=>x.BlogId).Take(1).ToList();
            }
        }
        public List<Blog> GetListLastTreeBlog(Expression<Func<Blog, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Blogs.Include(x=>x.Category).Include(x=>x.AppUser).OrderByDescending(x => x.BlogId).Take(3).ToList();
            }
        }

        public List<Blog> GetListFiveBlog(Expression<Func<Blog, bool>> Filter)
        {
            using (var ent = new Context())
            {
                return ent.Blogs.Include(x=>x.AppUser).Where(Filter).OrderByDescending(x=>x.BlogId).Take(5).ToList();
            }
        }
        public List<Blog> GetListTreeBlog(Expression<Func<Blog, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Blogs.Include(x => x.Category).Include(x => x.AppUser).OrderBy(x => x.BlogId).Take(3).ToList();
            }
        }

        public Blog GetBlogByIdWithWriterAndCategory(Expression<Func<Blog, bool>> Filter)
        {
            using (var ent=new Context())
            {
                return ent.Blogs.Include(x => x.AppUser).Include(y => y.Category).FirstOrDefault(Filter);
            }
        }
    }
}
