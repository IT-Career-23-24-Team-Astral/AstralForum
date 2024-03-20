using AstralForum.Data.Entities;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Thread
{
	public interface IThreadService
	{
		Task<ThreadDto> CreateThread(ThreadDto model, User createdBy);
		Task<ThreadDto> EditThread(ThreadDto commentDto);
		ThreadDto GetThreadById(int id);
		Task<ThreadDto> DeleteThread(ThreadDto commentDto);
		ThreadDto GetAllHiddenThreads();
		ThreadDto GetAllDeletedThreads();
		ThreadDto HideThread(int id);
		ThreadDto UnhideThread(int id);
		ThreadDto DeleteThread(int id);
		ThreadDto GetDeletedThreadBack(int id);

    }
}