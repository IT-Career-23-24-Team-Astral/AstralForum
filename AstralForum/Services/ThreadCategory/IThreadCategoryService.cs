using AstralForum.Data.Entities;
using AstralForum.ServiceModels;
using System.Threading.Tasks;

namespace AstralForum.Services.ThreadCategory
{
    public interface IThreadCategoryService
    {
        List<ThreadCategoryDto> GetAllThreadCategories();

        ThreadCategoryDto GetThreadCategoryById(int id);

        Task<ThreadCategoryDto> CreateThreadCategory(ThreadCategoryDto model, User createdBy);

        Task<ThreadCategoryDto> EditThreadCategory(ThreadCategoryDto threadCategoryDto, User createdBy);

        Task<ThreadCategoryDto> DeleteThreadCategory(ThreadCategoryDto threadCategoryDto, User createdBy);
    }
}
