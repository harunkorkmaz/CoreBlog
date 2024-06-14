using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Areas.Admin.Controllers;

[Area("Admin")]

[Route("Admin/[controller]")]
public class CategoryController(EfCategoryReposiyory categoryDal) : Controller
{
    private readonly EfCategoryReposiyory _categoryDal = categoryDal;

    [HttpGet("Index/{page?}")]
    public IActionResult Index(int page = 1)
    {
        var items = _categoryDal.GetListAll().ToPagedList(page, 3);
        return View(items);
    }

    [HttpGet("Add/")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("Add/")]
    public IActionResult Add(Tag model)
    {
        // model.CategoryStatus = true;
        //if (results.IsValid)
        //{
        _categoryDal.Insert(model);
        return RedirectToAction("Index");
        //}
        //else
        //{
        //    foreach (var item in results.Errors)
        //    {
        //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //    }
        //    return View();
        //}
    }

    [HttpPost("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        _categoryDal.Delete(_categoryDal.GetById(id));
        return RedirectToAction("Index");
    }
}
