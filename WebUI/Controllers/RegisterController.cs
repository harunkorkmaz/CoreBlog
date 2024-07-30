using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class RegisterController(UserManager<AppUser> userManger) : Controller
{
    private readonly UserManager<AppUser> _userManger = userManger;

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
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
                return Ok(new ApiResult { });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }

        return Ok(new ApiResult { IsSuccess = false });
    }
}