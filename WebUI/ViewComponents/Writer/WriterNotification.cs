using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer;

public class WriterNotification(EfNotificationRepository notificationdal) : ViewComponent
{
    private readonly EfNotificationRepository _notificationdal = notificationdal;

    public IViewComponentResult Invoke()
    {
        var vals = _notificationdal.GetListAll();
        return View(vals);
    }
}
