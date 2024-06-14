using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class Statistic2 : ViewComponent
    {
        BlogContext c = new BlogContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x => x.Id)?
                                .Take(1)
                                .Select(y => y.Title)
                                .FirstOrDefault();
            return View();
        }
    }
}
