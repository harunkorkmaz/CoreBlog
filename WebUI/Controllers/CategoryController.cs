using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CategoryController(EfCategoryReposiyory _categoryDal) : Controller
{
    public IActionResult Index()
    {
        return View(_categoryDal.GetListAll());
    }
}
