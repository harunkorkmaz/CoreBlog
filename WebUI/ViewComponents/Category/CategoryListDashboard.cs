using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Category;

public class CategoryListDashboard(ICategoryDal categoryDal) : ViewComponent
{
    private readonly ICategoryDal _categoryDal = categoryDal;
    public IViewComponentResult Invoke()
    {
        var item = _categoryDal.GetListAll();
        return View(item);
    }
}

