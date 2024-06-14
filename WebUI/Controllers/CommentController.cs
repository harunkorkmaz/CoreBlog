using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class CommentController(EfCommentRepository commentDal) : Controller
{
    private readonly EfCommentRepository _commentDal = commentDal;

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

        return new ApiResult
        {
            Message = "Yorumunuz başarıyla eklendi.",
        };
    }
}
