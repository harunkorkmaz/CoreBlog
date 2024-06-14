using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class DashboardController(UserManager<AppUser> userManager) : Controller
{
    private readonly UserManager<AppUser> _userManager = userManager;
    public IActionResult Index()
    {
        BlogContext a = new BlogContext();
        var userName = User.Identity?.Name;
        // var person = a.Writers.Where(x => x.Name == userName).FirstOrDefault();
        var person = _userManager.Users.Where(x => x.UserName == userName).FirstOrDefault();
        if (person == null)
            return View();

        ViewBag.v1 = a.Blogs.Count();
        ViewBag.v2 = a.Blogs.Where(x => x.UserId == person.Id).Count();
        ViewBag.v2 = 31;
        ViewBag.v3 = a.Tags.Count();
        return View();
    }
}
