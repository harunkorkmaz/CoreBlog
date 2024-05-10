using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class ContactController(IContactDal contactDal) : Controller
{
    private readonly IContactDal _contactDal = contactDal;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Contact person)
    {
        person.ContactDate = DateTime.Parse(DateTime.UtcNow.ToShortDateString());
        person.ContactStatus = true;
        _contactDal.Insert(person);
        return RedirectToAction("Index", "Blog");
    }
}
