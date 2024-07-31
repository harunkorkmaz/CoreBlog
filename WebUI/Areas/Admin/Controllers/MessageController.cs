using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class MessageController(EfMessageRepository message2dal, UserManager<AppUser> userManager, BlogContext blogContext) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Inbox()
    {
        var username = User.Identity.Name;
        var id = blogContext.Users.Where(x => x.FullName == username).Select(x => x.Id).FirstOrDefault();
        return View(message2dal.GetInboxMessageByWriter(id));
    }

    [HttpGet]
    public async Task<IActionResult> sendbox()
    {
        var username = User.Identity.Name;
        var id = blogContext.Users.Where(x => x.FullName == username).Select(x => x.Id).FirstOrDefault();
        var list = message2dal.GetInboxMessageByWriter(id);
        return View(list);
    }

    [HttpGet]
    public async Task<IActionResult> composeMail()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> composeMail(Message message, string toWho)
    {
        if (toWho == "" || toWho == null) { return BadRequest(); }
        var reciever = await userManager.FindByNameAsync(toWho);
        var recieverId = await blogContext.Users.Where(x => x.FullName == reciever.UserName).Select(x => x.Id).FirstOrDefaultAsync();
        var senderId = await blogContext.Users.Where(x => x.FullName == User.Identity.Name).Select(x => x.Id).FirstOrDefaultAsync();
        
        if (recieverId == null) 
            return BadRequest(); 
        message.RecieverId = recieverId;
        message.SenderId = senderId;

        message2dal.Insert(message);

        return RedirectToAction("sendbox");
    }
}

