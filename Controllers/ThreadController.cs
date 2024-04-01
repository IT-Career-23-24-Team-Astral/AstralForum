using AstralForum.Data.Entities;
using AstralForum.Models;
using AstralForum.Models.Thread;
using AstralForum.ServiceModels;
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
            if (threadForm.Text == null || threadForm.Description == null)
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