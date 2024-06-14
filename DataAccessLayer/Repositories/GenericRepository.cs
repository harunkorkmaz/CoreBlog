using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositores;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly BlogContext c;

    public GenericRepository(BlogContext context)
    {
        c = context;
    }

    public void Delete(T item)
    {
        c.Remove(item);
        c.SaveChanges();
    }

    public T GetById(int id)
    {
        return c.Set<T>().Find(id);
    }

    public List<T> GetListAll()
    {
        return [.. c.Set<T>()];
    }

    public void Insert(T item)
    {
        var itemType = item.GetType();
        var idProperty = itemType.GetProperty("Id");
        var idValue = idProperty.GetValue(item);

        if ((int)idValue == 0)
        {
            c.Add(item);
        }
        else
        {
            c.Update(item);
        }
        c.SaveChanges();
    }

    public void Update(T item)
    {
        c.Update(item);
        c.SaveChanges();
    }

    public List<T> GetAll(Expression<Func<T, bool>> filter)
    {
        return [.. c.Set<T>().Where(filter)];
    }
}
