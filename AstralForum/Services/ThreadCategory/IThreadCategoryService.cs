using AstralForum.ServiceModels;

namespace AstralForum.Services.ThreadCategory
{
	public interface IThreadCategoryService
	{
		IQueryable<ThreadCategoryDto> GetAllThreadCategories();

		ThreadCategoryDto GetThreadCategoryById(int id);

		Task<ThreadCategoryDto> CreateThreadCategory(ThreadCategoryDto threadCategoryDto);

		Task<ThreadCategoryDto> EditThreadCategory(ThreadCategoryDto threadCategoryDto);

		Task<ThreadCategoryDto> DeleteThread(ThreadCategoryDto threadCategoryDto);
	}
}
