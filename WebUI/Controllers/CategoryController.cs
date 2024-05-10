using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CategoryController(EfCategoryReposiyory categoryDal) : Controller
{
    private readonly EfCategoryReposiyory _categoryDal = categoryDal;
    public IActionResult Index()
    {
        return View(_categoryDal.GetListAll());
    }
}
