using AstralForum.Models.Thread;
using AstralForum.ServiceModels;
using AstralForum.Services.ThreadCategory;
using Microsoft.AspNetCore.Mvc;

namespace AstralForum.Controllers
{
	public class CategoryController : Controller
	{
		
		private readonly IThreadCategoryFacade threadCategoryFacade;

		public CategoryController(IThreadCategoryFacade threadCategoryFacade)
		{
			this.threadCategoryFacade = threadCategoryFacade;
		}


		public IActionResult Index(int id)
		{
			CategoryThreadsViewModel model = threadCategoryFacade.GetAllThreadsByCategoryId(id);

			return View(model);
		}
	}
}
