using AstralForum.Data.Entities.Thread;
using Thread = AstralForum.Data.Entities.Thread.Thread;

namespace AstralForum.Repositories
{
	public interface IThreadRepository : ICommonRepository<Thread>
	{
		Thread? GetThreadById(int id);
		void DeleteAllThreadsByUserId(int userId);
		int EditThread(int id, string newText, string newTitle);
		Task<List<Thread>> GetAllHiddenThreads();
		Task<List<Thread>> GetAllDeletedThreads();
		Thread HideThread(int id);
		Thread UnhideThread(int id);
		Thread DeleteThread(int id);
		Thread GetDeletedThreadBack(int id);
	}
}
