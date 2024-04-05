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
            ThreadDto databaseModel = threadService.GetThreadById(id);

            ThreadViewModel viewModel = new ThreadViewModel()
            {
                ThreadDto = databaseModel,
                CommentForm = new CommentAndReplyCreationFormModel()
            };

            return View(viewModel);
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
    }
}