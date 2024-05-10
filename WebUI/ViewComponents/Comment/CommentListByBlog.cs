using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents;

public class CommentListByBlog(ICommentDal commentDal) : ViewComponent
{
    ICommentDal _commentDal = commentDal;

    [HttpGet]
    public IViewComponentResult Invoke(int BlogId)
    {
        var item = _commentDal.GetAllwithUser(BlogId);
        return View(item);
    }
}

