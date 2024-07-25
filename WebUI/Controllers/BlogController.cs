using DataAccessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers;

public class BlogController(EfBlogRepository blogrepo, EfCommentRepository commentDal, EfCategoryReposiyory categoryDal, UserManager<AppUser> userManager) : Controller
{
    private readonly EfBlogRepository _blogDal = blogrepo;
    private readonly EfCommentRepository _commentDal = commentDal;
    private readonly EfCategoryReposiyory _categoryDal = categoryDal;
    private readonly UserManager<AppUser> _userManager = userManager;

    public IActionResult Detail(int id)
    {
        // ViewBag.CommentCount = _commentDal.GetAllwithUser(id).Count;
        ViewBag.CommentCount = 12;
        return View(_blogDal.GetById(id));
    }

    public IActionResult GetBLogByWriter()
    {
        var userName = User.Identity?.Name;
        if (userName == null)
            return RedirectToAction("Index", "Home");
        var userid = _userManager.Users.Where(x => x.UserName == userName).Select(x => x.Id).FirstOrDefault();
        return View(_blogDal.GetAll(userid));
    }

    [HttpGet]
    [Authorize]
    public IActionResult Add(int? id)
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
    public IActionResult Add(Blog p)
    {
        BlogValidator bv = new();
        var results = bv.Validate(p);
        if (results.IsValid)
        {
            _blogDal.Insert(p);
            return RedirectToAction("GetBlogByWriter", "Blog");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
    }

    [Authorize]
    public IActionResult BlogDelete(int id)
    {
        _blogDal.Delete(id);
        return RedirectToAction("GetBLogByWriter");
    }
}
