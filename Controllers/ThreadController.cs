using AstralForum.Data.Entities;
using AstralForum.Models;
using AstralForum.Models.Reaction;
using AstralForum.Models.Thread;
using AstralForum.ServiceModels;
using AstralForum.Services.Reaction;
using AstralForum.Services.Thread;
using AstralForum.Services.ThreadCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace AstralForum.Controllers
{
	public class ThreadController : Controller
	{
		private readonly IThreadFacade threadFacade;
		private readonly IThreadService threadService;
		private readonly IReactionFacade reactionFacade;
		private readonly IReactionService reactionService;
		private readonly UserManager<User> userManager;

		public ThreadController(IThreadFacade threadFacade, IThreadService threadService, IReactionFacade reactionFacade, IReactionService reactionService, UserManager<User> userManager)
		{
			this.threadFacade = threadFacade;
			this.threadService = threadService;
			this.reactionFacade = reactionFacade;
			this.reactionService = reactionService;
			this.userManager = userManager;
		}

		public async Task<IActionResult> Index(int id)
		{
			ThreadDto databaseModel = threadService.GetThreadById(id);

			ThreadViewModel viewModel = new ThreadViewModel()
			{
				ThreadDto = databaseModel,
				ReactionTypeDtos = await reactionService.GetAllReactionTypes(),
				CommentForm = new CommentAndReplyCreationFormModel()
			};

			return View(viewModel);
		}
		public IActionResult NoResultsThread()
		{
			if (TempData["ThreadDto.Id"] == null)
			{
				return RedirectToAction("Index", "Category");
			}
			else
			{
				int id = (int)TempData["ThreadDto.Id"];
				ThreadDto databaseModel = threadFacade.NoResultsThread(id);

				ThreadViewModel viewModel = new ThreadViewModel()
				{
					ThreadDto = databaseModel,
					CommentForm = new CommentAndReplyCreationFormModel()
				};

				return View(viewModel);
			}
		}
		public IActionResult SearchPostsByCreatedBy(int id, string searchQuery)
		{
			ViewData["CurrentFilter"] = searchQuery;
			ThreadDto model = threadFacade.SearchPostsByCreatedBy(id, searchQuery);


			if (model == null)
			{
				TempData["ThreadDto.Id"] = id;
				return RedirectToAction("NoResultsThread", "Thread");
			}
			else if (!string.IsNullOrEmpty(searchQuery))
			{
				ThreadViewModel viewModel = new ThreadViewModel()
				{
					ThreadDto = model,
					CommentForm = new CommentAndReplyCreationFormModel()
				};
				return View("~/Views/Thread/Index.cshtml", viewModel);
			}
			else if (string.IsNullOrEmpty(searchQuery))
			{
				TempData["ThreadDto.Id"] = id;
				return RedirectToAction("NoResultsThread", "Thread");
			}
			else
			{
				return RedirectToAction("Index", "Category");
			}
		}
		public IActionResult SearchPostsByText(int id, string searchQuery)
		{
			ViewData["CurrentFilter"] = searchQuery;
			ThreadDto model = threadFacade.SearchPostsByText(id, searchQuery);


			if (model == null)
			{
				TempData["ThreadDto.Id"] = id;
				return RedirectToAction("NoResultsThread", "Thread");
			}
			else if (!string.IsNullOrEmpty(searchQuery))
			{
				ThreadViewModel viewModel = new ThreadViewModel()
				{
					ThreadDto = model,
					CommentForm = new CommentAndReplyCreationFormModel()
				};
				return View("~/Views/Thread/Index.cshtml", viewModel);
			}
			else if (string.IsNullOrEmpty(searchQuery))
			{
				TempData["ThreadDto.Id"] = id;
				return RedirectToAction("NoResultsThread", "Thread");
			}
			else
			{
				return RedirectToAction("Index", "Category");
			}
		}
		public IActionResult SearchPostsByBoth(int id, string searchQuery)
		{
			ViewData["CurrentFilter"] = searchQuery;
			ThreadDto model = threadFacade.SearchPostsByBoth(id, searchQuery);


			if (model == null)
			{
				TempData["ThreadDto.Id"] = id;
				return RedirectToAction("NoResultsThread", "Thread");
			}
			else if (!string.IsNullOrEmpty(searchQuery))
			{
				ThreadViewModel viewModel = new ThreadViewModel()
				{
					ThreadDto = model,
					CommentForm = new CommentAndReplyCreationFormModel()
				};
				return View("~/Views/Thread/Index.cshtml", viewModel);
			}
			else if (string.IsNullOrEmpty(searchQuery))
			{
				TempData["ThreadDto.Id"] = id;
				return RedirectToAction("NoResultsThread", "Thread");
			}
			else
			{
				return RedirectToAction("Index", "Category");
			}
		}

		[Authorize]
		[Route("/Thread/Create/{categoryId}/{categoryName}")]
		public IActionResult Create(int categoryId, string categoryName)
		{
			ThreadCreationFormModel model = new ThreadCreationFormModel()
			{
				CategoryId = categoryId,
				CategoryName = categoryName
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		[Route("/Thread/Create/{categoryId}/{categoryName}")]
		public async Task<IActionResult> Create(ThreadCreationFormModel threadForm)
		{
			// TODO: Find a better way to handle serverside input validation
			if (threadForm.Title == null || threadForm.Text == null)
			{
				return RedirectToAction("Specify", "Category", new { id = threadForm.CategoryId });
			}

			await threadFacade.CreateThread(threadForm, await userManager.GetUserAsync(User));

			return RedirectToAction("Specify", "Category", new { id = threadForm.CategoryId });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public IActionResult Edit([FromForm] ThreadEditFormModel threadEditForm)
		{
			// TODO: secure server side the editing of a thread only by its creator
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index", new { id = threadEditForm.ThreadDtoId });
			}
			threadService.EditThread(threadEditForm.ThreadDtoId, threadEditForm.UpdatedText, threadEditForm.UpdatedTitle);
			return RedirectToAction("Index", new { id = threadEditForm.ThreadDtoId });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> AddThreadReaction([FromForm] ReactionThreadModel reactionThreadForm)
		{
			int updatedReactionCount = await reactionFacade.AddReactionToThread(reactionThreadForm.ThreadId, reactionThreadForm.ReactionTypeId, await userManager.GetUserAsync(User));

			return Json(new { reactionCount = updatedReactionCount });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> RemoveThreadReaction([FromForm] ReactionThreadRemovalModel reactionCommentRemovalForm)
		{
			int updatedReactionCount = await reactionFacade.RemoveThreadReaction(
				reactionCommentRemovalForm.ReactionThreadId,
				reactionCommentRemovalForm.ThreadId,
				reactionCommentRemovalForm.ReactionTypeId,
				await userManager.GetUserAsync(User));

			return Json(new { reactionCount = updatedReactionCount });
		}
	}
}