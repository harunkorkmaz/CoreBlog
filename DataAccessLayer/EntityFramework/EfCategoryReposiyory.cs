using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryReposiyory : GenericRepository<Category>
    {
        public List<Category> GetListAll()
        {
            using (var item = new Context())
            {
                return item.Catergories.ToList();
            }
        }

        public List<Category> GetListWithBlogs()
        {
            using (var item = new Context())
            {
                return item.Catergories.Include(x => x.Blogs).ToList();
            }
        }
    }
}
