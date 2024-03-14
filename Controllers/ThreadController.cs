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
            if (threadForm.Text == null || threadForm.Title == null)
            {
				return RedirectToAction("Specify", "Category", new { id = threadForm.CategoryId });
			}

            await threadFacade.CreateThread(threadForm, await userManager.GetUserAsync(User));

            return RedirectToAction("Specify", "Category", new { id = threadForm.CategoryId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddComment(ThreadViewModel threadViewModel)
        {
            CommentAndReplyCreationFormModel formData = threadViewModel.CommentForm;
            return RedirectToAction("Index", new { id = threadViewModel.ThreadDto.Id });
        }
    }
}