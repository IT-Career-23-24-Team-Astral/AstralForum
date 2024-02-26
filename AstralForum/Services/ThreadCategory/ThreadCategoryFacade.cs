using AstralForum.Models.Thread;
using AstralForum.ServiceModels;
using AstralForum.Services.Thread;

namespace AstralForum.Services.ThreadCategory
{
	public class ThreadCategoryFacade : IThreadCategoryFacade
	{
		private readonly IThreadCategoryService threadCategoryService;
		private readonly IThreadFacade threadFacade;

		public ThreadCategoryFacade(IThreadCategoryService threadCategoryService, IThreadFacade threadFacade)
		{
			this.threadCategoryService = threadCategoryService;
			this.threadFacade = threadFacade;
		}

		public CategoryThreadsViewModel GetAllThreadsByCategoryId(int categoryId)
		{
			ThreadCategoryDto threadCategoryDto = threadCategoryService.GetThreadCategoryById(categoryId);

			CategoryThreadsViewModel model = new CategoryThreadsViewModel()
			{
				CategoryName = threadCategoryDto.CategoryName,
				CategoryId = threadCategoryDto.Id,
				Threads = threadCategoryDto.Threads
					.OrderByDescending(t => t.CreatedOn)
					.Select(t => threadFacade.GetThreadTableViewModel(t))
			};

			return model;
		}
	}
}
