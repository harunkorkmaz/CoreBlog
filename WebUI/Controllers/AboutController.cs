using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class AboutController(EfAboutRepository aboutDal) : Controller
{
    public async Task<IActionResult> Index()
    {
        //aboutDal.GetListAll()
        return View();
    }
}
