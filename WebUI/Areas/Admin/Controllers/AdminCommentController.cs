using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]

public class AdminCommentController(EfCommentRepository commentDal) : Controller
{

    private readonly EfCommentRepository _commentDal = commentDal;

    public IActionResult Index()
    {
        var vals = _commentDal.GetListAll();
        return View(vals);
    }
}
