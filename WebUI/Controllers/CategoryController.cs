using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CategoryController(ICategoryDal categoryDal) : Controller
{
    private readonly ICategoryDal _categoryDal = categoryDal;
    public IActionResult Index()
    {
        return View(_categoryDal.GetListAll());
    }
}
