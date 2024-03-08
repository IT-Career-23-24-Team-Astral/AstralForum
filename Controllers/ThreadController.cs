using AstralForum.Data.Entities;
using AstralForum.Models.Thread;
using AstralForum.Services.Thread;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
	public class ThreadController : Controller
	{
		private readonly IThreadFacade threadFacade;
		private readonly UserManager<User> userManager;

		public ThreadController(IThreadFacade threadFacade, UserManager<User> userManager)
        {
            this.threadFacade = threadFacade;
            this.userManager = userManager;
        }

        public IActionResult Index(int id)
		{
			// ThreadViewModel model = new ThreadViewModel();
			return View();
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
	}
}
