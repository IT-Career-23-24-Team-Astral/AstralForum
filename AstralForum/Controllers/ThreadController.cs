using AstralForum.Data.Entities;
using AstralForum.Models;
using AstralForum.Models.Thread;
using AstralForum.ServiceModels;
using AstralForum.Services.Thread;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
	public class ThreadController : Controller
	{
		private readonly IThreadFacade threadFacade;
		private readonly IThreadService threadService;
		private readonly UserManager<User> userManager;

		public ThreadController(IThreadFacade threadFacade, IThreadService threadService, UserManager<User> userManager)
        {
            this.threadFacade = threadFacade;
			this.threadService = threadService;
            this.userManager = userManager;
        }

        public IActionResult Index(int id)
		{
			// TODO: remove this check
			if (id == 0)
			{
				return null;
			}
			ThreadDto databaseModel = threadService.GetThreadById(id);
			/*ThreadDto model = new ThreadDto()
			{
				Title = "Test thread title",
				Text = "Sample intresting thread test",
				ThreadCategoryId = 2,
				ThreadCategoryName = "A niche category",
				CreatedBy = new UserDto()
				{
					UserName = "interestingThreadCreator",
					DateOfCreation = DateTime.Now.AddHours(0.15)
				}
			};

			CommentDto comment = new CommentDto()
			{
				Id = 58,
				Text = "An angry comment",
				CreatedBy = new UserDto()
				{
					UserName = "interestingName",
					DateOfCreation = DateTime.Now
				}
			};

			CommentDto comment1 = new CommentDto()
			{
				Id = 59,
				Text = "An angry comment",
				CreatedBy = new UserDto()
				{
					UserName = "interestingName",
					DateOfCreation = DateTime.Now
				}
			};

			List<CommentDto> comments = new List<CommentDto>();
			comments.Add(comment);
			comments.Add(comment1);

			model.Comments = comments;*/

			ThreadViewModel viewModel = new ThreadViewModel()
			{
				ThreadDto = databaseModel,
				CommentForm = new CommentAndReplyCreationFormModel()
			};

			return View(viewModel);
		}

        [Authorize]
        public IActionResult Create(int id)
		{
			ThreadCreationFormModel model = new ThreadCreationFormModel()
			{
				CategoryId = id
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Create(ThreadCreationFormModel threadForm)
		{
			await threadFacade.CreateThread(threadForm, await userManager.GetUserAsync(User));

			return RedirectToAction("Index", "Category", new { id = threadForm.CategoryId });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public IActionResult AddComment(ThreadViewModel threadViewModel)
		{
			CommentAndReplyCreationFormModel formData = threadViewModel.CommentForm;


			
			return RedirectToAction("Index", new { id = threadViewModel.ThreadDto.Id});
		}
	}
}
