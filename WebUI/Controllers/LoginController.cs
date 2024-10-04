using DataAccessLayer.Concrete;
using DataAccessLayer.dto;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.Controllers;

public class LoginController(SignInManager<AppUser> _signInManager, EfUserRepository efUser) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ApiResult> Index(UserSignInViewModel model)
    {
        return await efUser.LoginAsync(model);
    }

    [Route("/login/logout")]
    public async Task<ApiResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return ApiResult.Success();
    }

    [HttpGet]
    public async Task<IActionResult> AccessDenied()
    {
        return View();
    }
}
