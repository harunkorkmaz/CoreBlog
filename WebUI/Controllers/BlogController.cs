using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers;

public class BlogController(EfBlogRepository _blogDal, EfCategoryReposiyory _categoryDal, UserManager<AppUser> _userManager) : Controller
{
    public async Task<IActionResult> Detail(int id)
    {
        ViewBag.CommentCount = 12;
        return View(_blogDal.GetById(id));
    }

    public async Task<IActionResult> GetBLogByWriter()
    {
        //_blogDal.GetAll(User.Identity?.Name ?? "")
        return View();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Add(int? id)
    {
        List<SelectListItem> categoryValues = (from x in _categoryDal.GetListAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
        var userName = User.Identity?.Name;
        var userid = _userManager.Users.Where(x => x.UserName == userName).Select(x => x.Id).FirstOrDefault();

        ViewBag.id = userid;
        ViewBag.cv = categoryValues;

        if (id != 0 && id != null)
        {
            var item = _blogDal.GetById((int)userid);
            return View(item);
        }
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(Blog p)
    {
        _blogDal.Insert(p);
        return RedirectToAction("GetBlogByWriter", "Blog");
    }

    [Authorize]
    public async Task<IActionResult> BlogDelete(int id)
    {
        return Ok(await _blogDal.DeleteAsync(id));
    }
}
