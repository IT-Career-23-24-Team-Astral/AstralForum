using AstralForum.Models.Thread;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
	public class ThreadController : Controller
	{
		public IActionResult Index()
		{
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
		public IActionResult Create(ThreadCreationFormModel newThread)
		{
			return RedirectToAction("Index", "Category", new { id = newThread.CategoryId });
		}
	}
}
