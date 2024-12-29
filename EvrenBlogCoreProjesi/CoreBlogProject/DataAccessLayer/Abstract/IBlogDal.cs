using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        public List<Blog> GetListBlogWithCategory(Expression<Func<Blog,bool>>Filter);
        public List<Blog> GetListBlogWithUser(Expression<Func<Blog,bool>>Filter);
        public List<Blog> GetListLastOneBlog(Expression<Func<Blog,bool>>Filter);
        public List<Blog> GetListLastTreeBlog(Expression<Func<Blog,bool>>Filter);
        public List<Blog> GetListTreeBlog(Expression<Func<Blog,bool>>Filter);
        public List<Blog> GetListFiveBlog(Expression<Func<Blog,bool>>Filter);
        public Blog GetBlogByIdWithWriterAndCategory(Expression<Func<Blog,bool>>Filter);
    }
}
