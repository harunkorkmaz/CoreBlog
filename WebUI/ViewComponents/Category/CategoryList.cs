using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Category
{
    [AllowAnonymous]
    public class CategoryList : ViewComponent
    {
        CategoryManager _categoryManager = new(new EfCategoryReposiyory());
        public IViewComponentResult Invoke()
        {
            var item = _categoryManager.GetListWithBlogs();
            return View(item);
        }
    }
}
