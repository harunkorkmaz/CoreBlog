using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer;

public class WriterMessageNotification(EfMessageRepository message2dal, BlogContext blogContext) : ViewComponent
{

    public IViewComponentResult Invoke()
    {
        var username = User.Identity.Name;
        int id = blogContext.Tags.Where(x => x.Name == username).Select(x => x.Id).FirstOrDefault();

        var list = message2dal.GetInboxMessageByWriter(id);
        ViewBag.Count = list.ToList().Count;
        if (list.Count > 3) { return View(list.Take(3).ToList()); }
        return View(list.ToList());
    }
}
