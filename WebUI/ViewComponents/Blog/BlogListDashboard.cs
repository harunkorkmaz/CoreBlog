using DataAccessLayer.dto;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog;

public class BlogListDashboard(EfBlogRepository blogrepo) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(FilterModel model)
    {
        return View(await blogrepo.GetAll(model));
    }
}
