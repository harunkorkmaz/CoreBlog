﻿using DataAccessLayer.dto;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class UserController(UserManager<AppUser> _userManager, EfUserRepository efUser) : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult WriterProfile(int? id)
    {
        return View();
    }

    public IActionResult Test(int? id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        return View(await efUser.EditGetUserAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserUpdateViewModel p)
    {
        var vals = await _userManager.FindByNameAsync(User.Identity.Name);
        if (vals == null)
            return NotFound();
        vals.UserName = p.username;
        vals.FullName = p.namesurname;
        vals.ImageUrl = p.imageurl;
        vals.PasswordHash = _userManager.PasswordHasher.HashPassword(vals, p.password);
        var res = await _userManager.UpdateAsync(vals);
        if (res.Succeeded)
            return RedirectToAction("Index", "Dashboard");
        return View();
    }
}