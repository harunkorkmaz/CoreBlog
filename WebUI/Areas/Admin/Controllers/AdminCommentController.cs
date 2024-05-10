using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]

public class AdminCommentController(ICommentDal commentDal) : Controller
{

    private readonly ICommentDal _commentDal = commentDal;

    public IActionResult Index()
    {
        var vals = _commentDal.GetListAll();
        return View(vals);
    }
}
