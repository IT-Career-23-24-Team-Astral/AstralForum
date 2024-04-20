using AstralForum.Data.Entities;
using AstralForum.Models.Categories;
using AstralForum.Models.Notification;
using AstralForum.Repositories;
using AstralForum.Repositories.Interfaces;
using AstralForum.Services.Notification;
using AstralForum.Services.ThreadCategory;
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
				return NoContent();
            }
        }






        public async Task<IActionResult> ReadNotification(int notificationId)
		{
			var user = await _userManager.GetUserAsync(User);
			var updatedNotificationDto = await _notificationRepository.ReadNotification(notificationId, user.Id);

			if (updatedNotificationDto != null)
			{
				return Ok(updatedNotificationDto);
			}
			else
			{
				return RedirectToAction("NoResultNotification", "Notification");
			}
		}
		
	}
}