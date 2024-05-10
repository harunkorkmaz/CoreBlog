using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer;

public class WriterNotification(INotificationDal notificationdal) : ViewComponent
{
    private readonly INotificationDal _notificationdal;

    public IViewComponentResult Invoke()
    {
        var vals = _notificationdal.GetListAll();
        return View(vals);
    }
}
