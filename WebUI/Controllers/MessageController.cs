using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class MessageController(EfMessageRepository messagedal, UserManager<AppUser> userManager) : Controller
{

    [HttpGet]
    public async Task<IActionResult> Inbox()
    {
        var username = User.Identity.Name;
        var id = userManager.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
        return View(messagedal.GetInboxMessageByWriter(id));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        return View(messagedal.GetById(id));
    }

    [HttpGet]
    public async Task<IActionResult> sendMessage()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> sendMessage(Message message)
    {
        var username = User.Identity.Name;
        var id = userManager.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
        message.SenderId = id;
        message.RecieverId = 2;
        message.Status = true;
        messagedal.Insert(message);
        return RedirectToAction("Inbox");
    }

    [HttpGet]
    public async Task<IActionResult> sendbox()
    {
        var username = User.Identity.Name;
        var id = userManager.Users.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
        var list = messagedal.GetSendboxMessageByWriter(id);
        return View(list);
    }
}

