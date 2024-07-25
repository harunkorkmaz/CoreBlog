
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.EntityFramework;

public class EfBlogRepository(BlogContext context)
{
    private readonly BlogContext blogContext = context;

    public List<Blog> GetAll()
    {
        var list = blogContext.Blogs
            .Include(x => x.Tags)
            .Where(x => !x.IsDeleted)
            .ToList();
        return list;
    }

    public List<Blog> GetAll(int WriterId)
    {
        var list = blogContext.Blogs
            .Include(x => x.Tags)
            .Where(x => x.UserId == WriterId && !x.IsDeleted)
            .ToList();

        return list;
    }

    public List<Blog> GetAll(Expression<Func<Blog, bool>> filter)
    {
        return blogContext.Set<Blog>()
            .Where(filter)
            .ToList();
    }

    public void Delete(int id)
    {
        var item = blogContext.Blogs.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
        if (item != null)
        {
            item.IsDeleted = true;
            blogContext.SaveChanges();
        }
    }

    public int Insert(Blog item)
    {
        blogContext.Blogs.Add(item);
        blogContext.SaveChanges();
        return item.Id;
    }

    public Blog GetById(int id)
    {
        return blogContext.Blogs
            .Include(x => x.Tags)
            .Where(x => x.Id == id && !x.IsDeleted)
            .FirstOrDefault();
    }
}
