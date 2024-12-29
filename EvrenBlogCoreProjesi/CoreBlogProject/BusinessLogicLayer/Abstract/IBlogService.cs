using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        public List<Blog> GetListBlogWithCategoryAndWriter();
        public List<Blog> GetListMyBlog(int id);
        public List<Blog> GetLastOneBlog();
        public List<Blog> GetLastTreeBlog();
        public List<Blog> GetTreeBlog();
        public List<Blog> GetFiveBlog();
        public Blog GetBlogById(int id);
    }
}
