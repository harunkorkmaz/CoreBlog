using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer;

public class WriterAboutonDashboard(EfWriterRepository writerdal) : ViewComponent
{
    private readonly EfWriterRepository _writerdal = writerdal;
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
