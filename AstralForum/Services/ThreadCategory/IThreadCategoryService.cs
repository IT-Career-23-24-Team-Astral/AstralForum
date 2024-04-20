using AstralForum.Data.Entities;
using AstralForum.Models.ThreadCategory;
using AstralForum.ServiceModels;
using System.Threading.Tasks;

namespace AstralForum.Services.ThreadCategory
{
    public interface IThreadCategoryService
    {
        List<ThreadCategoryDto> GetAllThreadCategories();
        List<ThreadCategoryDto> SearchThreadCategoriesByName(string searchQuery);
        List<ThreadCategoryDto> SearchThreadCategoriesByCreatedBy(string searchQuery);
        List<ThreadCategoryDto> SearchThreadCategoriesByBoth(string searchQuery);

        ThreadCategoryDto GetThreadCategoryById(int id);
       
        List<ThreadCategoryDto> SearchThreadByTitle(int id, string searchQuery);
        List<ThreadCategoryDto> SearchThreadByCreatedBy(int id, string searchQuery);



        Task<ThreadCategoryDto> CreateThreadCategory(ThreadCategoryDto model, User createdBy);

        Task<ThreadCategoryDto> EditThreadCategory(ThreadCategoryDto threadCategoryDto, User createdBy);

        Task<ThreadCategoryDto> DeleteThreadCategory(ThreadCategoryDto threadCategoryDto, User createdBy);
    }
}
