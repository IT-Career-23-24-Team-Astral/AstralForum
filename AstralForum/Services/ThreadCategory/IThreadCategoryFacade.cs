using AstralForum.Data.Entities;
using AstralForum.Models.Categories;
using AstralForum.Models.Thread;
using AstralForum.Models.ThreadCategory;
using AstralForum.ServiceModels;

namespace AstralForum.Services.ThreadCategory
{
    public interface IThreadCategoryFacade
    {

            CategoryTableViewModel GetThreadCategoryTableViewModel(ThreadCategoryDto threadCategoryDto);

            Task<ThreadCategoryDto> CreateThreadCategory(CategoryCreateViewModel threadCategoryForm, User createdBy);
            Task<ThreadCategoryDto> EditThreadCategory(CategoryIndexViewModel threadCategoryForm, User createdById);
        Task<ThreadCategoryDto> DeleteThreadCategory(CategoryIndexViewModel threadCategoryForm, User createdById);
        CategoryThreadsViewModel GetAllThreadsByCategoryId(int categoryId);
        CategoryViewModel GetAllThreadCategories();

    }
}