
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog;

[AllowAnonymous]
public class WriterLastBlogs(EfBlogRepository blogrepo) : ViewComponent
{
    private readonly EfBlogRepository _blogrepo = blogrepo;

    [HttpGet]
    public IViewComponentResult Invoke(int id)
    {
        var vals = _blogrepo?.GetAll(id);
        return View(vals);
    }
}
