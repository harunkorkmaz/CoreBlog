using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.EntityFramework;

public class EfBlogRepository : GenericRepository<Blog>
{
    public List<Blog> GetAll()
    {
        using var item = new Context();
        var list = item.Blogs
            .Include(x => x.Category)
            .Where(x => !x.isDeleted)
            .ToList();

        return list;
    }

    public List<Blog> GetAll(int WriterId)
    {
        using var item = new Context();
        var list = item.Blogs
            .Include(x => x.Category)
            .Where(x => x.WriterId == WriterId && !x.isDeleted)
            .ToList();

        return list;
    }

    public List<Blog> GetAll(Expression<Func<Blog, bool>> filter)
    {
        using var c = new Context();
        return c.Set<Blog>()
            .Where(filter)
            .ToList();
    }

    public void Delete(int id)
    {
        using var c = new Context();
        var item = c.Blogs.Where(x => x.Id == id && !x.isDeleted).FirstOrDefault();
        if (item != null)
        {
            item.isDeleted = true;
            c.SaveChanges();
        }
    }
}
