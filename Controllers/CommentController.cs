using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Models.Notification;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Services;
using AstralForum.Services.Comment;
using AstralForum.Services.Notification;
using AstralForum.Services.Thread;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace AstralForum.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentFacade _commentFacade;
		private readonly ICommentService _commentService;
		private readonly INotificationFacade _notificationFacade;
		private readonly INotificationService _notificationService;
		private readonly UserManager<User> _userManager;
		private readonly IThreadService _threadService;

		public CommentController(ICommentFacade commentFacade,
								ICommentService commentService,
								INotificationFacade notificationFacade,
								UserManager<User> userManager,
                                IThreadService threadService,
								INotificationService notificationService)
		{
			_commentFacade = commentFacade;
			_commentService = commentService;
			_notificationFacade = notificationFacade;
			_notificationService = notificationService;
			_userManager = userManager;
            _threadService = threadService;
		}

		public async Task<IActionResult> CommentReplies(int commentId)
		{
			List<CommentDto> comments = await _commentService.GetAllRepliesByCommentId(commentId);

			var serializeOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				Converters =
				{
					new DateTimeJsonConverter()
				}
			};

			return Json(comments, serializeOptions);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
        // TODO: fix attachments not to be shown as null
        public IActionResult CreateNotification(int id)
        {
            NotificationCreateViewModel model = new NotificationCreateViewModel()
            {
                NotificationId = id
            };
            return View(model);
        }
        public async Task<IActionResult> AddThreadComment(ThreadViewModel viewModel, int threadId)
		{
			ThreadDto thread = _threadService.GetThreadById(threadId);

            var user = await _userManager.GetUserAsync(User);
			if (viewModel.CommentForm.Text == null)
			{
				return RedirectToAction("Index", "Thread", new { id = threadId });
			}

			await _commentFacade.CreateComment(viewModel.CommentForm, threadId, user);

            
            // Create notification
            NotificationDto notification = new NotificationDto
            {
				Text = $"{user.UserName} commented on your thread",
				User = thread.CreatedBy,
				UserId = thread.CreatedById,
				Date = DateTime.Now,

            };
			await _notificationService.CreateNotification(notification, thread.CreatedById);

			return RedirectToAction("Index", "Thread", new { id = threadId });
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		// TODO: fix attachments not to be shown as null
		public async Task<IActionResult> AddCommentReply(ThreadViewModel viewModel, int threadId)
		{
            int commentId = viewModel.CommentForm.CommentId;
            ThreadDto thread = _threadService.GetThreadById(threadId);
			CommentDto comment = _commentService.GetCommentById(viewModel.CommentForm.CommentId);

            var user = await _userManager.GetUserAsync(User);

            if (viewModel.CommentForm.Text == null)
			{
				return RedirectToAction("Index", "Thread", new { id = threadId });
			}

			
			
			await _commentFacade.CreateComment(viewModel.CommentForm, threadId, await _userManager.GetUserAsync(User), commentId);
            
			NotificationDto notification = new NotificationDto
            {
                Text = $"{user.UserName} commented on your thread",
                User = thread.CreatedBy,
                UserId = thread.CreatedById,
                Date = DateTime.Now,

            };
            await _notificationService.CreateNotification(notification, thread.CreatedById);

            NotificationDto notificationTwo = new NotificationDto
            {
                Text = $"{user.UserName} replied to your comment",
                User = comment.CreatedBy,
                UserId = comment.CreatedById,
                Date = DateTime.Now,

            };
            await _notificationService.CreateNotification(notificationTwo, comment.CreatedById);

            return RedirectToAction("Index", "Thread", new { id = threadId });
		}
	}
}
