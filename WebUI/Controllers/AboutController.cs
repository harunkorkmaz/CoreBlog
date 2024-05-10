using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class AboutController(EfAboutRepository aboutDal) : Controller
{
    private readonly EfAboutRepository _aboutDal = aboutDal;

    public IActionResult Index()
    {
        var items = _aboutDal.GetListAll();
        return View(items);
    }
}
