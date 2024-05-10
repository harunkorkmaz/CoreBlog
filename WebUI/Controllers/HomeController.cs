using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class HomeController(EfBlogRepository blogrepo) : Controller
{
    private readonly EfBlogRepository _blogrepo = blogrepo;

    public IActionResult Index()
    {
        return View(_blogrepo.GetAll());
    }
}

