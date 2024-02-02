using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Thread;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models.Category;
using AstralForum.Models.Thread;

namespace AstralForum.Repositories.Interfaces
{
    public interface IThreadRepository : ICommonRepository<Post>
    {
        public void AddThread(ThreadFormModel model, User id);
        public List<ThreadViewModel> GetAllThreadsByThreadCategory(int ThreadCategory);
        public void Edit(Post thread, ThreadFormModel model);
        public void Delete(Post thread);
    }
}
