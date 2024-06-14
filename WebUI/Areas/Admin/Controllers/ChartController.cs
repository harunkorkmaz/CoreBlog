using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            var mlist = new List<CategoryClass>();

            mlist.Add(new CategoryClass
            {
                Name = "Tech",
                categorycount = 4
            }
            );
            mlist.Add(new CategoryClass
            {
                Name = "Software",
                categorycount = 1
            }
            );
            mlist.Add(new CategoryClass
            {
                Name = "Linux",
                categorycount = 2
            }
            );
            return Json(new { jsonlist = mlist });
        }
    }
}
