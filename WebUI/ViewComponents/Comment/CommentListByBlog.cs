using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents;

public class CommentListByBlog(EfCommentRepository commentDal) : ViewComponent
{
    private readonly EfCommentRepository _commentDal = commentDal;

    [HttpGet]
    public IViewComponentResult Invoke(int BlogId)
    {
        var item = _commentDal.GetAllwithUser(BlogId);
        return View(item);
    }
}

