using DataAccessLayer.dto;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class HomeController(EfBlogRepository _blogrepo) : Controller
{
    public async Task<IActionResult> Index(FilterModel model)
    {
        return View(await _blogrepo.GetAll(model));
    }
}
