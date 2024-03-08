using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models.Categories;
using AstralForum.Models.Thread;
using AstralForum.Models.ThreadCategory;
using AstralForum.ServiceModels;
using AstralForum.Services.Thread;

namespace AstralForum.Services.ThreadCategory
{
    public class ThreadCategoryFacade : IThreadCategoryFacade
    {
        private readonly IThreadCategoryService threadCategoryService;
        private readonly IThreadFacade threadFacade;

        public ThreadCategoryFacade(IThreadCategoryService threadCategoryService, IThreadFacade threadFacade)
        {
            this.threadCategoryService = threadCategoryService;
            this.threadFacade = threadFacade;
        }

        public CategoryTableViewModel GetThreadCategoryTableViewModel(ThreadCategoryDto threadCategoryDto)
        {
            CategoryTableViewModel model = new CategoryTableViewModel()
            {
                Id = threadCategoryDto.Id,
                CategoryName = threadCategoryDto.CategoryName,
                DateOfCreation = threadCategoryDto.CreatedOn,
                Author = threadCategoryDto.CreatedBy,
                Description = threadCategoryDto.Description
            };

            return model;
        }

        public async Task<ThreadCategoryDto> CreateThreadCategory(CategoryCreateViewModel threadCategoryForm, User createdBy)
        {
            // TODO: handle attachment upload and setting urls in the DTO

            ThreadCategoryDto threadCategoryDto = new ThreadCategoryDto()
            {
                CategoryName = threadCategoryForm.CategoryName,
                Description = threadCategoryForm.Description,
                Id = threadCategoryForm.CategoryId,
                CreatedBy = createdBy.ToDto()
            };

            return await threadCategoryService.CreateThreadCategory(threadCategoryDto);
        }
        public async Task<ThreadCategoryDto> EditThreadCategory(CategoryIndexViewModel threadCategoryForm, User createdBy)
        {

            ThreadCategoryDto threadCategoryDto = new ThreadCategoryDto()
            {
                ImageUrl = threadCategoryForm.ImageUrl,
                CategoryName = threadCategoryForm.CategoryName,
                Description = threadCategoryForm.Description,
                Id = threadCategoryForm.CategoryId,
                CreatedBy = createdBy.ToDto()
            };

            return await threadCategoryService.EditThreadCategory(threadCategoryDto);
        }

        public async Task<ThreadCategoryDto> DeleteThreadCategory(CategoryIndexViewModel threadCategoryForm, User createdBy)
        {

            ThreadCategoryDto threadCategoryDto = new ThreadCategoryDto()
            {
                ImageUrl = threadCategoryForm.ImageUrl,
                CategoryName = threadCategoryForm.CategoryName,
                Description = threadCategoryForm.Description,
                Id = threadCategoryForm.CategoryId,
                CreatedBy = createdBy.ToDto()
            };

            return await threadCategoryService.DeleteThreadCategory(threadCategoryDto);
        }

        public CategoryThreadsViewModel GetAllThreadsByCategoryId(int categoryId)
        {
            ThreadCategoryDto threadCategoryDto = threadCategoryService.GetThreadCategoryById(categoryId);

            CategoryThreadsViewModel model = new CategoryThreadsViewModel()
            {
                CategoryName = threadCategoryDto.CategoryName,
                CategoryId = threadCategoryDto.Id,
                Threads = threadCategoryDto.Threads
                    .OrderByDescending(t => t.CreatedOn)
                    .Select(t => threadFacade.GetThreadTableViewModel(t))
            };

            return model;
        }
        public CategoryViewModel GetAllThreadCategories()
        {
            List<ThreadCategoryDto> allCategories = threadCategoryService.GetAllThreadCategories();

            // Filter categories based on the specified categoryId
            

            // Map ThreadCategoryDto to CategoryIndexViewModel
            List<CategoryIndexViewModel> categoryViewModels = allCategories.Select(tc => new CategoryIndexViewModel
            {
                CategoryName = tc.CategoryName,
                Description = tc.Description,
                Author = tc.CreatedBy
            }).ToList();

            // Construct the view model
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = categoryViewModels
            };

            return model;
        }

    }
}
