using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBlogController() : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }
}
