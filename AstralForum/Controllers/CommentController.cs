using AstralForum.Data.Entities;
using AstralForum.Models;
using AstralForum.Models.Reaction;
using AstralForum.ServiceModels;
using AstralForum.Services;
using AstralForum.Services.Comment;
using AstralForum.Services.Thread;
using AstralForum.Services.Reaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using AstralForum.Services.Notification;

namespace AstralForum.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentFacade _commentFacade;
		private readonly ICommentService _commentService;
		private readonly IThreadService _threadService;
		private readonly INotificationService _notificationService;
		private readonly IReactionFacade _reactionFacade;
		private readonly UserManager<User> _userManager;
        private readonly TimeoutService _timeoutService;
		public CommentController(ICommentFacade commentFacade,
			ICommentService commentService,
			IThreadService threadService, INotificationService notificationService, IReactionFacade reactionFacade, UserManager<User> userManager, TimeoutService timeoutService)
		{
			_commentFacade = commentFacade;
			_commentService = commentService;
			_threadService = threadService;
			_notificationService = notificationService;
			_reactionFacade = reactionFacade;
			_userManager = userManager;
			_timeoutService = timeoutService;

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
		public async Task<IActionResult> AddCommentReaction([FromForm] ReactionCommentModel reactionCommentForm)
		{
            CommentDto comment = _commentService.GetCommentById(reactionCommentForm.CommentId);
			ThreadDto thread = _threadService.GetThreadById(comment.ThreadId);

            var user = await _userManager.GetUserAsync(User);
            int updatedReactionCount = await _reactionFacade.AddReactionToComment(reactionCommentForm.CommentId, reactionCommentForm.ReactionTypeId, await _userManager.GetUserAsync(User));
            NotificationDto notification = new NotificationDto
            {
                Text = $"{user.UserName} reacted on your comment on{thread.CreatedBy.UserName}'s thread {thread.Title}",
                User = comment.CreatedBy,
                UserId = comment.CreatedById,
                Date = DateTime.Now,

            };
            await _notificationService.CreateNotification(notification, comment.CreatedById);

            return Json(new { reactionCount = updatedReactionCount });

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> RemoveCommentReaction([FromForm] ReactionCommentRemovalModel reactionCommentRemovalForm)
		{
			int updatedReactionCount = await _reactionFacade.RemoveCommentReaction(
				reactionCommentRemovalForm.ReactionCommentId,
				reactionCommentRemovalForm.CommentId,
				reactionCommentRemovalForm.ReactionTypeId,
				await _userManager.GetUserAsync(User));

            

            return Json(new { reactionCount = updatedReactionCount });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> AddThreadComment(ThreadViewModel viewModel, int threadId)
		{
            ThreadDto thread = _threadService.GetThreadById(threadId);

            var user = await _userManager.GetUserAsync(User);
            bool isUserInTimeout = await _timeoutService.IsUserTimeout(await _userManager.GetUserAsync(User));
            if (isUserInTimeout)
            {
                return RedirectToAction("Timeout", "Home");
            }
            if (viewModel.CommentForm.Text == null)
			{
				return RedirectToAction("Index", "Thread", new { id = threadId });
			}

			await _commentFacade.CreateComment(viewModel.CommentForm, threadId, await _userManager.GetUserAsync(User));
            NotificationDto notification = new NotificationDto
            {
                Text = $"{user.UserName} commented on your thread{thread.Title}",
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
		public async Task<IActionResult> AddCommentReply(ThreadViewModel viewModel, int threadId)
		{
            int commentId = viewModel.CommentForm.CommentId;
            ThreadDto thread = _threadService.GetThreadById(threadId);
            CommentDto comment = _commentService.GetCommentById(viewModel.CommentForm.CommentId);
            var user = await _userManager.GetUserAsync(User);
            bool isUserInTimeout = await _timeoutService.IsUserTimeout(await _userManager.GetUserAsync(User));
            if (isUserInTimeout)
            {
                return RedirectToAction("Timeout", "Home");
            }
            if (viewModel.CommentForm.Text == null)
			{
				return RedirectToAction("Index", "Thread", new { id = threadId });
			}

			
			
			await _commentFacade.CreateComment(viewModel.CommentForm, threadId, await _userManager.GetUserAsync(User), commentId);
            NotificationDto notification = new NotificationDto
            {
                Text = $"{user.UserName} commented on your thread {thread.Title}",
                User = thread.CreatedBy,
                UserId = thread.CreatedById,
                Date = DateTime.Now,

            };
            await _notificationService.CreateNotification(notification, thread.CreatedById);

            NotificationDto notificationTwo = new NotificationDto
            {
                Text = $"{user.UserName} replied to your comment on {thread.CreatedBy.UserName}'s thread {thread.Title}",
                User = comment.CreatedBy,
                UserId = comment.CreatedById,
                Date = DateTime.Now,

            };
            await _notificationService.CreateNotification(notificationTwo, comment.CreatedById);

            return RedirectToAction("Index", "Thread", new { id = threadId });
		}
		[Authorize(Roles = "Admin, Moderator")]
		[HttpGet]
		public IActionResult HideComment(int id)
		{
			var thread = _commentService.HideComment(id);

			string returnUrl = HttpContext.Request.Headers["Referer"];
			return Redirect(returnUrl);
		}
	}
}
