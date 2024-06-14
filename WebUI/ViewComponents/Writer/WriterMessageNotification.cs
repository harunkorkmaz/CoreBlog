using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer;

public class WriterMessageNotification(EfMessageRepository message2dal) : ViewComponent
{
    private readonly EfMessageRepository _message2dal = message2dal;

    public IViewComponentResult Invoke()
    {
        var username = User.Identity.Name;
        var context = new BlogContext();
        int id = context.Tags.Where(x => x.Name == username).Select(x => x.Id).FirstOrDefault();

        var list = _message2dal.GetInboxMessageByWriter(id);
        ViewBag.Count = list.ToList().Count;
        if (list.Count > 3) { return View(list.Take(3).ToList()); }
        return View(list.ToList());
    }
}
