using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        Context a = new Context();
        var userName = User.Identity?.Name;
        var person = a.Writers.Where(x => x.WriterName == userName).FirstOrDefault();
        if (person == null)
            return View();

        ViewBag.v1 = a.Blogs.Count();
        ViewBag.v2 = a.Blogs.Where(x => x.WriterId == person.Id).Count();
        ViewBag.v3 = a.Catergories.Count();
        return View();
    }
}
