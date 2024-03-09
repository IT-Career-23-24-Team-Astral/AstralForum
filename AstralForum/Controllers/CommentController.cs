using AstralForum.Data.Entities;
using AstralForum.Models;
using AstralForum.ServiceModels;
using AstralForum.Services;
using AstralForum.Services.Comment;
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
		private readonly UserManager<User> _userManager;

		public CommentController(ICommentFacade commentFacade, ICommentService commentService, UserManager<User> userManager)
		{
			_commentFacade = commentFacade;
			_commentService = commentService;
			_userManager = userManager;
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
		public async Task<IActionResult> AddThreadComment(ThreadViewModel viewModel, int threadId)
		{
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
		// TODO: fix attachments not to be shown as null
		public async Task<IActionResult> AddCommentReply(ThreadViewModel viewModel, int threadId)
		{
			if (viewModel.CommentForm.Text == null)
			{
				return RedirectToAction("Index", "Thread", new { id = threadId });
			}

			int commentId = viewModel.CommentForm.CommentId;
			
			await _commentFacade.CreateComment(viewModel.CommentForm, threadId, await _userManager.GetUserAsync(User), commentId);

			return RedirectToAction("Index", "Thread", new { id = threadId });
		}
	}
}
