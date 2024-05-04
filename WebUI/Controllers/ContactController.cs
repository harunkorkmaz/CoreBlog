using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        
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
            cm.ContactAdd(person);
            return RedirectToAction("Index", "Blog");
        }
    }
}
