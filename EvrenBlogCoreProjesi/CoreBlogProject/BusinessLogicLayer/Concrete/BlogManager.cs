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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }

        public List<Blog> GetLastOneBlog()
        {
           return _blogdal.GetListLastOneBlog(x=>x.BlogStatus==true);
        }

        public List<Blog> GetLastTreeBlog()
        {
            return _blogdal.GetListLastTreeBlog(x=>x.BlogStatus==true);
        }

        public List<Blog> GetListBlogWithCategoryAndWriter()
        {
           return _blogdal.GetListBlogWithCategory(x=>x.BlogStatus==true);
        }
        public List<Blog> GetListMyBlog(int id)
        {
           return _blogdal.GetListBlogWithUser(x => x.AppUserId == id&&x.BlogStatus==true);
        }

        public List<Blog> GetFiveBlog()
        {
           return _blogdal.GetListFiveBlog(x => x.BlogStatus == true && x.BlogId % 2 == 1);
        }

        public List<Blog> GetTreeBlog()
        {
           return _blogdal.GetListTreeBlog(x=>x.BlogStatus==true);
        }

        public void TDelete(Blog t)
        {
            _blogdal.DeleteRow(t);
        }

        public Blog TGetById(int id)
        {
            return _blogdal.GetById(id);
        }

        public List<Blog> TGetListAll()
        {
           return _blogdal.GetListAll(x=>x.BlogStatus==true);
        }

        public List<Blog> TGetListByCondition()
        {
            throw new NotImplementedException();
        }

        public Blog TGetValueByCondition()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Blog t)
        {
            _blogdal.InsertRow(t);
        }

        public void TUpdate(Blog t)
        {
            _blogdal.UpdateRow(t);
        }

        public Blog GetBlogById(int id)
        {
           return _blogdal.GetBlogByIdWithWriterAndCategory(x=>x.BlogId==id);
        }
    }
}
