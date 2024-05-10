using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBlogController(EfBlogRepository blogDal) : Controller
{
    private readonly EfBlogRepository _blogDal = blogDal;

    public async Task<IActionResult> Index()
    {
        return View(_blogDal.GetAll());
    }
}
