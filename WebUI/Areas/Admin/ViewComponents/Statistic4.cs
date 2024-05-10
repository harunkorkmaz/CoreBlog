using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents;

public class Statistic4 : ViewComponent
{
    Context c = new Context();
    public IViewComponentResult Invoke()
    {
        ViewBag.v1 = c.Admins.Where(x => x.Id == 2).FirstOrDefault();
        return View();
    }
}
