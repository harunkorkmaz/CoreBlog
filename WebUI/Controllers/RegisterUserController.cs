using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

[AllowAnonymous]
public class RegisterUserController(UserManager<AppUser> userManger) : Controller
{
    private readonly UserManager<AppUser> _userManger = userManger;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("/RegisterUser")]
    public async Task<IActionResult> Index(UserSignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            AppUser user = new AppUser()
            {
                Email = model.Mail,
                FullName = model.FullName,
                UserName = model.UserName,
                ImageUrl = "aa"
            };
            var result = await _userManger.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }

        return View();
    }
}