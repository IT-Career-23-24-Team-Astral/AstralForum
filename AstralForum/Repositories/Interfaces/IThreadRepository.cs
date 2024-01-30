using AstralForum.Data.Entities.Comment;
using AstralForum.Models.Category;

namespace AstralForum.Repositories.Interfaces
{
    public interface IThreadRepository : ICommonRepository<Thread>
    {
        public IEnumerable<CategoryViewModel> GetCategory();
    }
}
