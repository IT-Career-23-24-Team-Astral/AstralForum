using AstralForum.Models.Thread;

namespace AstralForum.Services.ThreadCategory
{
	public interface IThreadCategoryFacade
	{
		CategoryThreadsViewModel GetAllThreadsByCategoryId(int categoryId);
	}
}
