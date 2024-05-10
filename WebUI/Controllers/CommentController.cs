using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class CommentController(ICommentDal commentDal) : Controller
{
    private readonly ICommentDal _commentDal = commentDal;

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public PartialViewResult PartialAddComment()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult PartialAddComment(Comment model)
    {
        model.CommentStatus = true;
        if (model.Score == 0)
            model.Score = 5;
        _commentDal.Insert(model);

        // sql trigger sildigim icin burda kendim ekleme yapiyorum
        using (var context = new Context())
        {
            BlogRating RatingRow = context.BlogRatings.FirstOrDefault(x => x.BLogId == model.BlogId);
            if (RatingRow == null)
            {
                RatingRow = new BlogRating();
                RatingRow.BLogId = model.BlogId;
                RatingRow.RatingCount = 1;
                RatingRow.TotalScore = model.Score;
                context.BlogRatings.Add(RatingRow);
                context.SaveChanges();
            }
        }

        return RedirectToAction("Details", "Blog", new { id = model.BlogId });
    }
}
