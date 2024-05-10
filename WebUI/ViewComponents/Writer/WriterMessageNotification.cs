using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer;

public class WriterMessageNotification(EfMessage2Repository message2dal) : ViewComponent
{
    private readonly EfMessage2Repository _message2dal = message2dal;

    public IViewComponentResult Invoke()
    {
        var username = User.Identity.Name;
        var context = new Context();
        int id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();

        var list = _message2dal.GetInboxMessageByWriter(id);
        ViewBag.Count = list.ToList().Count;
        if (list.Count > 3) { return View(list.Take(3).ToList()); }
        return View(list.ToList());
    }
}
