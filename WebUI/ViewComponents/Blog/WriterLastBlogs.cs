using DataAccessLayer.dto;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog;

public class WriterLastBlogs(EfBlogRepository blogrepo) : ViewComponent
{
    [HttpGet]
    public IViewComponentResult Invoke(FilterModel model, int id)
    {
        return View(blogrepo?.GetAll(model, id));
    }
}
