using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog;

[AllowAnonymous]
public class WriterLastBlogs(IBlogDal blogDal) : ViewComponent
{
    private readonly IBlogDal _blogDal = blogDal;

    [HttpGet]
    public IViewComponentResult Invoke(int id)
    {
        var vals = _blogDal?.GetAll(id);
        return View(vals);
    }
}
