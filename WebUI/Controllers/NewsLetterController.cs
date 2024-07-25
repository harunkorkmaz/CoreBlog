using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class NewsLetterController(EfNewsLetterRepository newsLetter) : Controller
{

    [HttpGet]
    public PartialViewResult SubscribeMail()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult SubscribeMail(int id, NewsLetter model)
    {
        model.MailStatus = true;
        newsLetter.Insert(model);
        return RedirectToAction("Details", "Blog", new { id = id });
    }
}
