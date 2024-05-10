using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Category;

[AllowAnonymous]
public class CategoryList(EfCategoryReposiyory categoryDal) : ViewComponent
{
    private readonly EfCategoryReposiyory _categoryDal = categoryDal;

    public IViewComponentResult Invoke()
    {
        var item = _categoryDal.GetListWithBlogs();
        return View(item);
    }
}
