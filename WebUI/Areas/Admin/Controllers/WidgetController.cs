using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class WidgetController : Controller
{
    [Route("/admin/")]
    [Route("/admin/widget")]
    public IActionResult Index()
    {
        return View();
    }
}
