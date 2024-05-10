using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class AboutController(IAboutDal aboutDal) : Controller
{
    IAboutDal _aboutDal = aboutDal;

    public IActionResult Index()
    {
        var items = _aboutDal.GetListAll();
        return View(items);
    }
}
