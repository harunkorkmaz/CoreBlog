using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class AboutController(EfAboutRepository aboutDal) : Controller
{

    public IActionResult Index()
    {
        var items = aboutDal.GetListAll();
        return View(items);
    }
}
