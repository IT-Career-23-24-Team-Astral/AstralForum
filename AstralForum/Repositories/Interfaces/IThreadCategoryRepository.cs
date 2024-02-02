using AstralForum.Models.Category;
using AstralForum.Models.Thread;
using AstralForum.Data.Entities;
using NuGet.Common;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.ThreadCategory;

namespace AstralForum.Repositories.Interfaces
{
    public interface IThreadCategoryRepository : ICommonRepository<ThreadCategory>
    {
        public void AddThreadCategory(ThreadCategoryFormModel model, User id);
        public ThreadCategoryViewModel CategoryDetails(int id);
        public List<ThreadCategoryViewModel> GetAllThreadGategories();
        public void Edit(ThreadCategory threadCategory, ThreadCategoryFormModel model);
        public void Delete(ThreadCategory threadCategory);
    }
}
