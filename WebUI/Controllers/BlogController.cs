using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers;

public class BlogController(IUserDal userDal, EfBlogRepository blogrepo, EfCommentRepository commentDal, EfCategoryReposiyory categoryDal) : Controller
{
    private readonly EfBlogRepository _blogrepo = blogrepo;
    private readonly EfCommentRepository _commentDal = commentDal;
    private readonly IUserDal _userDal = userDal;
    private readonly EfCategoryReposiyory _categoryDal = categoryDal;

    [AllowAnonymous]
    public IActionResult Details(int id)
    {
        ViewBag.CommentCount = _commentDal.GetAllwithUser(id).Count();
        return View(_blogrepo.GetById(id));
    }

    [AllowAnonymous]
    public IActionResult GetBLogByWriter()
    {
        var userName = User.Identity?.Name;
        if (userName == null)
            return RedirectToAction("Index", "Home");
        var userid = _userDal.GetCurrentUserId(userName);
        return View(_blogrepo.GetAll(userid));
    }

    [HttpGet]
    public IActionResult BlogAdd(int? id)
    {
        List<SelectListItem> categoryValues = (from x in _categoryDal.GetListAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.Id.ToString()
                                               }).ToList();
        var userName = User.Identity?.Name;
        Context c = new Context();
        var userid = c.Writers.Where(x => x.WriterName == userName).Select(y => y.Id).FirstOrDefault();

        ViewBag.id = userid;
        ViewBag.cv = categoryValues;

        if (id != 0 && id != null)
        {
            var item = _blogrepo.GetById((int)userid);
            return View(item);
        }
        return View();
    }

    [HttpPost]
    public IActionResult BlogAdd(Blog p)
    {
        BlogValidator bv = new BlogValidator();
        var results = bv.Validate(p);
        if (results.IsValid)
        {
            p.CreatedDate = DateTime.UtcNow;

            // sql trigger sildigim icin burda kendim ekleme yapiyorum
            // writerId artik Identity den aliniyor
            using (var context = new Context())
            {
                var username = User.Identity.Name;
                var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
                p.WriterId = id;

                _blogrepo.Insert(p);

                BlogRating newRatingRow = new BlogRating { BLogId = p.Id, RatingCount = 0, TotalScore = 0 };
                context.BlogRatings.Add(newRatingRow);
                context.SaveChanges();
            }

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

    public IActionResult BlogDelete(int id)
    {
        _blogrepo.Delete(id);
        return RedirectToAction("GetBLogByWriter");
    }
}
