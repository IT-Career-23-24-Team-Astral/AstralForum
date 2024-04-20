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

namespace AstralForum.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentFacade _commentFacade;
		private readonly ICommentService _commentService;
		private readonly IReactionFacade _reactionFacade;
		private readonly UserManager<User> _userManager;
        private readonly TimeoutService _timeoutService;
		public CommentController(ICommentFacade commentFacade, ICommentService commentService, IReactionFacade reactionFacade, UserManager<User> userManager, TimeoutService timeoutService)
		{
			_commentFacade = commentFacade;
			_commentService = commentService;
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
			int updatedReactionCount = await _reactionFacade.AddReactionToComment(reactionCommentForm.CommentId, reactionCommentForm.ReactionTypeId, await _userManager.GetUserAsync(User));
			
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

			return RedirectToAction("Index", "Thread", new { id = threadId });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> AddCommentReply(ThreadViewModel viewModel, int threadId)
		{
            bool isUserInTimeout = await _timeoutService.IsUserTimeout(await _userManager.GetUserAsync(User));
            if (isUserInTimeout)
            {
                return RedirectToAction("Timeout", "Home");
            }
            if (viewModel.CommentForm.Text == null)
			{
				return RedirectToAction("Index", "Thread", new { id = threadId });
			}

			int commentId = viewModel.CommentForm.CommentId;
			
			await _commentFacade.CreateComment(viewModel.CommentForm, threadId, await _userManager.GetUserAsync(User), commentId);

			return RedirectToAction("Index", "Thread", new { id = threadId });
		}
		[Authorize(Roles = "Admin")]
		[HttpGet]
		public IActionResult HideComment(int id)
		{
			var thread = _commentService.HideComment(id);

			string returnUrl = HttpContext.Request.Headers["Referer"];
			return Redirect(returnUrl);
		}
	}
}
