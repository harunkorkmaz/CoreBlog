using DataAccessLayer.dto;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class CommentController(EfCommentRepository _commentDal) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult PartialAddComment()
    {
        return PartialView();
    }

    [HttpPost]
    public ApiResult PartialAddComment(Comment model)
    {
        _commentDal.Insert(model);

        return ApiResult.Success();
    }
}
