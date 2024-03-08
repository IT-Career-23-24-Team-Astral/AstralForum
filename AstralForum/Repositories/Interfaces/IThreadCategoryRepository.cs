using AstralForum.Data.Entities;
using NuGet.Common;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.Models;

namespace AstralForum.Repositories.Interfaces
{
    public interface ThreadCategoryRepository : ICommonRepository<ThreadCategory>
    {
        public void AddThreadCategory(ThreadCategoryModel model, User id);
        public ThreadCategoryModel CategoryDetails(int id);
        public List<ThreadCategoryModel> GetAllThreadGategories();
        public void Edit(ThreadCategory threadCategory, ThreadCategoryModel model);
        public void Delete(ThreadCategory threadCategory);
    }
}
