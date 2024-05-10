using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class NotificationController(EfNotificationRepository notificationdal) : Controller
{
    private readonly EfNotificationRepository _notificationdal = notificationdal;

    public IActionResult Index()
    {
        return View();
    }
    [AllowAnonymous]
    public IActionResult AllNotification()
    {

        return View(_notificationdal.GetListAll());
    }
}
