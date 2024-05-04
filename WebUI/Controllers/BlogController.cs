using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Controllers
{

    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        private readonly IUserDal _userDal;
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());

        public BlogController(IUserDal userDal)
        {
            _userDal = userDal;
        }

        //[AllowAnonymous]
        //public IActionResult Index()
        //{
        //    return View(_blogManager.GetList());
        //}

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            ViewBag.CommentCount =  _commentManager.GetList(id).Count();
            return View(_blogManager.GetBlogById(id));
        }

        [AllowAnonymous]
        public IActionResult GetBLogByWriter()
        {
            var userName = User.Identity?.Name;
            if (userName == null)
                return RedirectToAction("Index", "Home");
            var userid = _userDal.GetCurrentUserId(userName);
            return View(_blogManager.GetBlogByWriter(userid));
        }

        [HttpGet]
        public IActionResult BlogAdd(int? id)
        {

            CategoryManager cm = new CategoryManager(new EfCategoryReposiyory());
            List<SelectListItem> categoryValues = (from x in cm.GetList()
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
                var item = _blogManager.GetBlogById((int)userid);
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
                    _blogManager.TAdd(p);
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
            _blogManager.DeleteBlog(id);
            return RedirectToAction("GetBLogByWriter");
        }
    }
}
