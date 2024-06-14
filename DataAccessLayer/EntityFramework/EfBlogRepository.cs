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
        using var item = new BlogContext();
        var list = item.Blogs
            .Include(x => x.Tags)
            .Where(x => !x.IsDeleted)
            .ToList();
        return list;
    }

    public List<Blog> GetAll(int WriterId)
    {
        using var item = new BlogContext();
        var list = item.Blogs
            .Include(x => x.Tags)
            .Where(x => x.UserId == WriterId && !x.IsDeleted)
            .ToList();

        return list;
    }

    public List<Blog> GetAll(Expression<Func<Blog, bool>> filter)
    {
        using var c = new BlogContext();
        return c.Set<Blog>()
            .Where(filter)
            .ToList();
    }

    public void Delete(int id)
    {
        using var c = new BlogContext();
        var item = c.Blogs.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
        if (item != null)
        {
            item.IsDeleted = true;
            c.SaveChanges();
        }
    }
}
