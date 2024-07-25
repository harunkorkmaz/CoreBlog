using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfCategoryReposiyory(BlogContext context)
{
    private readonly BlogContext _context = context;

    public List<Tag> GetListAll()
    {
        return [.. _context.Tags];
    }

    public List<Tag> GetListWithBlogs()
    {
        return [.. _context.Tags.Include(x => x.Blogs)];
    }

    public int Insert(Tag item)
    {
        _context.Tags.Add(item);
        _context.SaveChanges();
        return item.Id;
    }

    // getbyid
    public Tag GetById(int id)
    {
        return _context.Tags.Find(id);
    }

    public void Delete(Tag item)
    {
        _context.Tags.Remove(item);
        _context.SaveChanges();
    }
}
