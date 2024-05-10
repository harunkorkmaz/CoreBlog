using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebUI.Areas.Admin.ViewComponents;

public class Statistic1(IBlogDal blogDal) : ViewComponent
{
    private readonly IBlogDal _blogDal = blogDal;
    private readonly Context context = new();

    public IViewComponentResult Invoke()
    {
        string apiKey = "0fd75240baf47c86acec3fdeb7e68895";
        string city = "istanbul";
        string apiPath = $"https://api.openweathermap.org/data/2.5/weather?q=istanbul&appid=0fd75240baf47c86acec3fdeb7e68895&mode=xml ";
        ViewBag.BlogCount = _blogDal.GetAll().Count();
        ViewBag.MessageCount = context.Contacts.Count();
        ViewBag.CommentCount = context.Comments.Count();
        XDocument x = XDocument.Load(apiPath);
        ViewBag.weather = Convert.ToDouble(x.Descendants("temperature").ElementAt(0).Attribute("value").Value) - 273;
        return View();
    }
}
