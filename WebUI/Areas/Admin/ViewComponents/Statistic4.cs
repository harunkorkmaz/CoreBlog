using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents;

public class Statistic4(BlogContext blogContext) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.v1 = blogContext.Admins.Where(x => x.Id == 2).FirstOrDefault();
        return View();
    }
}
