
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents;

public class CommentListByBlog(EfCommentRepository commentDal) : ViewComponent
{

    [HttpGet]
    public IViewComponentResult Invoke(int BlogId)
    {
        // var item = commentDal.GetAllwithUser(BlogId);
        return View(14);
    }
}

