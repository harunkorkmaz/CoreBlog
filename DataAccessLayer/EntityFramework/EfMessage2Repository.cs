using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfMessageRepository(BlogContext blogContext)
{

    public List<Message> GetInboxMessageByWriter(int id)
    {
        return [.. blogContext.Messages.Where(x => x.RecieverId == id)];
    }

    public List<Message> GetSendboxMessageByWriter(int id)
    {
        return [.. blogContext.Messages.Where(x => x.SenderId == id)];
    }

    public Message GetById(int id)
    {
        return blogContext.Messages.Find(id);
    }

    public int Insert(Message item)
    {
        blogContext.Messages.Add(item);
        blogContext.SaveChanges();
        return item.Id;
    }
}
