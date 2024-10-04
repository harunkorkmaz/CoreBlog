using DataAccessLayer.dto;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class RegisterController(UserManager<AppUser> userManger, EfUserRepository efUser) : Controller
{

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ApiResult> Index(UserSignUpViewModel model)
    {
        return await efUser.RegisterAsync(model);
    }
}