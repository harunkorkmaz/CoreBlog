using DataAccessLayer.Concrete;

using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.EntityFramework;

public class EfCommentRepository 
{
    private readonly BlogContext _context;

    public EfCommentRepository(BlogContext context)
    {
        _context = context;
    }

    public List<Comment> GetAll(int blogId)
    {
        return _context.Comments.Where(x => x.BlogId == blogId).ToList();
    }

    public List<Comment> GetAll()
    {
        return _context.Comments.Include(x => x.Blog).ToList();
    }

    public List<Comment> GetAllWithUser(int blogId)
    {
        return _context.Comments.Include(x => x.User).Where(x => x.BlogId == blogId).ToList();
    }

    public int Insert(Comment item)
    {
        _context.Comments.Add(item);
        _context.SaveChanges();
        return item.Id;
    }

    public List<Comment> GetListAll()
    {
        return [.. _context.Comments];
    }

}
