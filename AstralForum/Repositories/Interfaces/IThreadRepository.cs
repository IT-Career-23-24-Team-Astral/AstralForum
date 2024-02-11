using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Thread;
using AstralForum.Models;
namespace AstralForum.Repositories.Interfaces
{
    public interface IThreadRepository : ICommonRepository<Post>
    {
        public void AddThread(ThreadModel model, User id);
        public List<ThreadModel> GetAllThreadsByThreadCategory(int ThreadCategory);
        public void Edit(Post thread, ThreadModel model);
        public void Delete(Post thread);
    }
}
