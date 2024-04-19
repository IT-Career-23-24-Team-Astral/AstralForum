using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Thread
{
	public interface IThreadService
	{
		Task<ThreadDto> CreateThread(ThreadDto model, User createdBy);
		int EditThreadText(int id, string newText);
		ThreadDto GetThreadById(int id);
		ThreadDto GetThreadByThreadIdWithReactions(int id);
		Task<ThreadDto> DeleteThread(ThreadDto commentDto);
        Task<List<ThreadDto>> GetAllHiddenThreads();
        Task<List<ThreadDto>> GetAllDeletedThreads();
		ThreadDto HideThread(int id);
		ThreadDto UnhideThread(int id);
		ThreadDto DeleteThread(int id);
		ThreadDto GetDeletedThreadBack(int id);
        void DeleteAllThreadsByUserId(int id);
		List<ThreadDto> SearchPostsByCreatedBy(int id, string searchQuery);
		List<ThreadDto> SearchPostsByText(int id, string searchQuery);
		List<ThreadDto> SearchPostsByBoth(int id, string searchQuery);

	}
}