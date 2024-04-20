using AstralForum.Data.Entities;
using AstralForum.Models.Categories;
using AstralForum.Models.Notification;
using AstralForum.Models.ThreadCategory;
using AstralForum.Repositories;
using AstralForum.Repositories.Interfaces;
using AstralForum.Services.Notification;
using AstralForum.Services.ThreadCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AstralForum.Controllers
{

	public class NotificationController : Controller
	{
		private NotificationRepository _notificationRepository;
		private readonly INotificationFacade _notificationFacade;
		private UserManager<User> _userManager;
		public NotificationController(NotificationRepository notificationRepository,INotificationFacade notificationFacade,
										UserManager<User> userManager)
		{
			_notificationRepository = notificationRepository;
			_notificationFacade = notificationFacade;
			_userManager = userManager;
		}
		
		public IActionResult CreateNotification(int id)
		{
			NotificationCreateViewModel model = new NotificationCreateViewModel()
			{
				NotificationId = id
			};
			return View(model);
		}


        public async Task<IActionResult> GetUserNotifications()
        {
            var user = await _userManager.GetUserAsync(User);
            NotificationModel notifications = await _notificationFacade.GetUserNotifications(user.Id);

            if (notifications != null && notifications.UserNotifications.Count > 0)
            {
                return View(notifications);
            }
            else
            {
                ViewBag.Message = "You have no new notifications.";
                return View();
            }
        }

        public async Task<IActionResult> GetUserReadNotifications()
        {
            var user = await _userManager.GetUserAsync(User);
            NotificationModel notifications = await _notificationFacade.GetUserReadNotifications(user.Id);

            if (notifications != null && notifications.UserNotifications.Count > 0)
            {
                return View(notifications);
            }
            else
            {
                ViewBag.Message = "You have no old notifications.";
                return View();
            }
        }
        public async Task<IActionResult> ReadNotification(int notificationId)
		{
			var user = await _userManager.GetUserAsync(User);
			var updatedNotificationDto = await _notificationRepository.ReadNotification(notificationId, user.Id);
            return RedirectToAction("GetUserNotifications", "Notification");
        }
        public IActionResult DeleteNotification(int id)
        {
            GetUserNotificationViewModel model = new GetUserNotificationViewModel()
            {
                NotificationId = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNotification(GetUserNotificationViewModel notificationForm)
        {
            await _notificationFacade.DeleteNotification(notificationForm, await _userManager.GetUserAsync(User));

            return RedirectToAction("GetUserReadNotifications", "Notification");
        }
    }
}