using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Category;

public class CategoryListDashboard(EfCategoryReposiyory categoryDal) : ViewComponent
{
    private readonly EfCategoryReposiyory _categoryDal = categoryDal;
    public IViewComponentResult Invoke()
    {
        var item = _categoryDal.GetListAll();
        return View(item);
    }
}

