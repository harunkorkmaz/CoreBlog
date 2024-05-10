using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer;

public class WriterAboutonDashboard(UserManager<AppUser> userManager, IWriterDal writerdal) : ViewComponent
{
    private readonly IWriterDal _writerdal = writerdal;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly Context c = new Context();

    public IViewComponentResult Invoke(int id)
    {
        var name = User.Identity?.Name;
        if (name == null)
            return View(_writerdal.GetById(1));
            
        var userid = c.Writers.Where(x=> x.WriterName == name).Select(y=>y.Id).FirstOrDefault();
        var mail = c.Writers.Where(x=> x.WriterName == name).Select(y=>y.WriterMail).FirstOrDefault();
            
        var val = _writerdal.GetById(userid);
        return View(val);
    }
}
