using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class MessageController(IMessage2Dal message2dal) : Controller
{
    private readonly IMessage2Dal _message2dal = message2dal;

    [HttpGet]
    public async Task<IActionResult> Inbox()
    {
        var username = User.Identity.Name;
        var context = new Context();
        var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
        return View(_message2dal.GetInboxMessageByWriter(id));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        return View(_message2dal.GetById(id));
    }

    [HttpGet]
    public async Task<IActionResult> sendMessage()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> sendMessage(Message2 message)
    {
        var username = User.Identity.Name;
        var context = new Context();
        var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
        message.SenderId = id;
        message.RecieverId = 2;
        message.Status = true;
        _message2dal.Insert(message);
        return RedirectToAction("Inbox");
    }

    [HttpGet]
    public async Task<IActionResult> sendbox()
    {
        var username = User.Identity.Name;
        var context = new Context();
        var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
        var list = _message2dal.GetSendboxMessageByWriter(id);
        return View(list);
    }
}

