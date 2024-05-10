using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog;

public class BlogListDashboard(EfBlogRepository blogrepo) : ViewComponent
{
    private readonly EfBlogRepository _blogrepo = blogrepo;

    public IViewComponentResult Invoke()
    {
        var vals = _blogrepo.GetAll().Take(3).ToList();
        return View(vals);
    }
}
