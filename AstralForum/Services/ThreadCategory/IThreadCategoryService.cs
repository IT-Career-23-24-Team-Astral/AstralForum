using AstralForum.ServiceModels;
using System.Threading.Tasks;

namespace AstralForum.Services.ThreadCategory
{
    public interface IThreadCategoryService
    {
        List<ThreadCategoryDto> GetAllThreadCategories();

        ThreadCategoryDto GetThreadCategoryById(int id);

        Task<ThreadCategoryDto> CreateThreadCategory(ThreadCategoryDto model);

        Task<ThreadCategoryDto> EditThreadCategory(ThreadCategoryDto threadCategoryDto);

        Task<ThreadCategoryDto> DeleteThreadCategory(ThreadCategoryDto threadCategoryDto);
    }
}
