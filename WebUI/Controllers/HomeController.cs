using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class HomeController(IBlogDal blogDal) : Controller
{
    private readonly IBlogDal _blogDal = blogDal;

    public IActionResult Index()
    {
        return View(_blogDal.GetAll());
    }
}

