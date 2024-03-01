using AstralForum.Data.Entities;
using AstralForum.Models;
using AstralForum.Services.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentFacade _commentFacade;
		private readonly UserManager<User> _userManager;

		public CommentController(ICommentFacade commentFacade, UserManager<User> userManager)
		{
			_commentFacade = commentFacade;
			_userManager = userManager;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> AddThreadComment(ThreadViewModel viewModel, int threadId)
		{
			await _commentFacade.CreateComment(viewModel.CommentForm, threadId, await _userManager.GetUserAsync(User));

			return RedirectToAction("Index", "Thread", new { id = threadId });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		// TODO: fix attachments not to be shown as null
		public async Task<IActionResult> AddCommentReply(ThreadViewModel viewModel, int commentId, int threadId)
		{
			await _commentFacade.CreateComment(viewModel.CommentForm, threadId, await _userManager.GetUserAsync(User), commentId);

			return RedirectToAction("Index", "Thread", new { id = threadId });
		}
	}
}
