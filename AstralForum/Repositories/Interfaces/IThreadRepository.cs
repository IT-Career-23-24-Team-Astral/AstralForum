using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Thread;
using AstralForum.Models;
namespace AstralForum.Repositories.Interfaces
{
    public interface IThreadRepository : ICommonRepository<Data.Entities.Thread.Thread>
    {
        public void AddThread(ThreadModel model, User id);
        public List<ThreadModel> GetAllThreadsByThreadCategory(int ThreadCategory);
        public void Edit(Data.Entities.Thread.Thread thread, ThreadModel model);
        public void Delete(Data.Entities.Thread.Thread thread);
    }
}
