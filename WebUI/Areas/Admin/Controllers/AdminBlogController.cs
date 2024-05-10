using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]

public class AdminBlogController(IBlogDal blogDal) : Controller
{
    private readonly IBlogDal _blogDal = blogDal;

    public async Task<IActionResult> Index()
    {
        return View(_blogDal.GetAll());
    }
}
