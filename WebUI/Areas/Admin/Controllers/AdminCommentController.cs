using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]

public class AdminCommentController(EfCommentRepository commentDal) : Controller
{
    public IActionResult Index()
    {
        var vals = commentDal.GetListAll();
        return View(vals);
    }
}
