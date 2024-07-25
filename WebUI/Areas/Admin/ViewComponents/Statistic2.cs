using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class Statistic2(BlogContext blogContext) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = blogContext.Blogs.OrderByDescending(x => x.Id)?
                                .Take(1)
                                .Select(y => y.Title)
                                .FirstOrDefault();
            return View();
        }
    }
}
