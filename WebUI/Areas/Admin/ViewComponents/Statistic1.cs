using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebUI.Areas.Admin.ViewComponents;

public class Statistic1() : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
