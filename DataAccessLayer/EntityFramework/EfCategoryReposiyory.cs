using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfCategoryReposiyory : GenericRepository<Tag>
{
    public List<Tag> GetListAll()
    {
        using var item = new BlogContext();
        return item.Tags.ToList();
    }

    public List<Tag> GetListWithBlogs()
    {
        using var item = new BlogContext();
        return item.Tags.Include(x => x.Blogs).ToList();
    }
}
