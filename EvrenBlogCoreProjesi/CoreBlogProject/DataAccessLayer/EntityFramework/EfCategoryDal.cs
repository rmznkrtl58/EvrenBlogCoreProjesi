using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public Category GetCategoryValueById(Expression<Func<Category,bool>>Filter)
        {
            using (var ent=new Context())
            {
                return ent.Categories.Where(Filter).FirstOrDefault();
            }
        }
    }
}
