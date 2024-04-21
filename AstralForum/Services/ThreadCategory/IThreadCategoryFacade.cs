using AstralForum.Data.Entities;
using AstralForum.Models.Categories;
using AstralForum.Models.Thread;
using AstralForum.Models.ThreadCategory;
using AstralForum.ServiceModels;

namespace AstralForum.Services.ThreadCategory
{
    public interface IThreadCategoryFacade
    {

        
            Task<ThreadCategoryDto> CreateThreadCategory(CategoryCreateViewModel threadCategoryForm, User createdBy);
            Task<ThreadCategoryDto> EditThreadCategory(CategoryIndexViewModel threadCategoryForm, User createdById);
        Task<ThreadCategoryDto> DeleteThreadCategory(CategoryIndexViewModel threadCategoryForm, User createdById);
        CategoryThreadsViewModel GetAllThreadsByCategoryId(int categoryId);
		CategoryThreadsViewModel SearchThreadByTitle(int id, string searchQuery);
        CategoryThreadsViewModel SearchThreadByCreatedBy(int id, string searchQuery);

        CategoryThreadsViewModel NoResults(int categoryId);
        CategoryViewModel GetAllThreadCategories();
        CategoryViewModel SearchThreadCategoriesByName(string searchQuery);
        CategoryViewModel SearchThreadCategoriesByCreatedBy(string searchQuery);
        CategoryViewModel SearchThreadCategoriesByBoth(string searchQuery);

    }
}