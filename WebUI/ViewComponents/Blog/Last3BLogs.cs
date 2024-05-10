using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog;

public class Last3Blogs(IBlogDal blogDal) : ViewComponent
{
    private readonly IBlogDal _blogDal = blogDal;

    public IViewComponentResult Invoke()
    {
        var vals = _blogDal.GetAll().Take(3).ToList();
        return View(vals);
    }
}

