﻿using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class MessageController(EfMessage2Repository message2dal, UserManager<AppUser> userManager) : Controller
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly EfMessage2Repository _message2dal = message2dal;

    [HttpGet]
    public async Task<IActionResult> Inbox()
    {
        var username = User.Identity.Name;
        var context = new Context();
        var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
        return View(_message2dal.GetInboxMessageByWriter(id));
    }

    [HttpGet]
    public async Task<IActionResult> sendbox()
    {
        var username = User.Identity.Name;
        var context = new Context();
        var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
        var list = _message2dal.GetInboxMessageByWriter(id);
        return View(list);
    }

    [HttpGet]
    public async Task<IActionResult> composeMail()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> composeMail(Message2 message, string toWho)
    {
        if (toWho == "" || toWho == null) { return BadRequest(); }
        var reciever = await _userManager.FindByNameAsync(toWho);
        var context = new Context();
        var recieverId = await context.Writers.Where(x => x.WriterName == reciever.UserName).Select(x => x.Id).FirstOrDefaultAsync();
        var senderId = await context.Writers.Where(x => x.WriterName == User.Identity.Name).Select(x => x.Id).FirstOrDefaultAsync();
        if (recieverId == null) { return BadRequest(); }
        message.RecieverId = recieverId;
        message.SenderId = senderId;

        _message2dal.Insert(message);

        return RedirectToAction("sendbox");
    }
}

