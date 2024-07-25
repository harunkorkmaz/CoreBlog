using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class DashboardController(UserManager<AppUser> userManager, BlogContext blogContext) : Controller
{
    private readonly UserManager<AppUser> _userManager = userManager;
   
    public IActionResult Index()
    {
        var userName = User.Identity?.Name;
        var person = _userManager.Users.Where(x => x.UserName == userName).FirstOrDefault();
        if (person == null)
            return View();

        ViewBag.v1 = blogContext.Blogs.Count();
        ViewBag.v2 = blogContext.Blogs.Where(x => x.UserId == person.Id).Count();
        ViewBag.v2 = 31;
        ViewBag.v3 = blogContext.Tags.Count();
        return View();
    }
}
