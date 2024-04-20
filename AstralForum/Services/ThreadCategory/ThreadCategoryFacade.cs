using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models.Categories;
using AstralForum.Models.Thread;
using AstralForum.Models.ThreadCategory;
using AstralForum.ServiceModels;
using AstralForum.Services.Thread;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

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

        public async Task<ThreadCategoryDto> CreateThreadCategory(CategoryCreateViewModel threadCategoryForm, User createdBy)
        {
            // TODO: handle attachment upload and setting urls in the DTO

            ThreadCategoryDto threadCategoryDto = new ThreadCategoryDto()
            {
                CategoryName = threadCategoryForm.CategoryName,
                Description = threadCategoryForm.Description,
                Id = threadCategoryForm.CategoryId,
                CreatedBy = createdBy.ToDto(),
                CreatedById = createdBy.Id
            };

            return await threadCategoryService.CreateThreadCategory(threadCategoryDto, createdBy);
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

            return await threadCategoryService.EditThreadCategory(threadCategoryDto, createdBy);
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

            return await threadCategoryService.DeleteThreadCategory(threadCategoryDto, createdBy);
        }

        
        public CategoryThreadsViewModel SearchThreadByTitle(int id, string searchQuery)
        {
            List<ThreadCategoryDto> allCategories = threadCategoryService.SearchThreadByTitle(id, searchQuery);

            // Check if any categories are found
            if (allCategories == null || !allCategories.Any())
            {
                return null;
            }
            else
            {
                ThreadCategoryDto selectedCategory = allCategories.First();

                var filteredThreads = selectedCategory.Threads
                                        .Where(t => t.Title.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase));

                // Create the CategoryViewModel
                CategoryThreadsViewModel model = new CategoryThreadsViewModel
                {
                    CategoryName = selectedCategory.CategoryName,
                    CategoryId = selectedCategory.Id,
                    Threads = filteredThreads
                                .OrderByDescending(t => t.CreatedOn)
                                .Select(t => threadFacade.GetThreadTableViewModel(t)),
                    Description = selectedCategory.Description
                };

                return model;
            }
        }



        public CategoryThreadsViewModel SearchThreadByCreatedBy(int id,string searchQuery)
        {
            List<ThreadCategoryDto> allCategories = threadCategoryService.SearchThreadByCreatedBy(id, searchQuery);

            // Check if any categories are found
            if (allCategories == null || !allCategories.Any())
            {
                // Return a model with a specific CategoryId if no categories are found
                return null;
            }
            else
            {
                ThreadCategoryDto selectedCategory = allCategories.First();

                var filteredThreads = selectedCategory.Threads
                                        .Where(t => t.CreatedBy.UserName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase));

                // Create the CategoryViewModel
                CategoryThreadsViewModel model = new CategoryThreadsViewModel
                {
                    CategoryName = selectedCategory.CategoryName,
                    CategoryId = selectedCategory.Id,
                    Threads = filteredThreads
                                .OrderByDescending(t => t.CreatedOn)
                                .Select(t => threadFacade.GetThreadTableViewModel(t)),
                    Description = selectedCategory.Description
                };

                return model;
            }
        }

        public CategoryViewModel GetAllThreadCategories()
        {
            List<ThreadCategoryDto> allCategories = threadCategoryService.GetAllThreadCategories();

            // Map ThreadCategoryDto to CategoryIndexViewModel
            List<CategoryIndexViewModel> categoryViewModels = allCategories.Select(tc => new CategoryIndexViewModel
            {
                CategoryName = tc.CategoryName,
                Description = tc.Description,
                Author = tc.CreatedBy,
                CategoryId = tc.Id
            }).ToList();

            // Construct the view model
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = categoryViewModels
            };

            return model;
        }
        public CategoryViewModel SearchThreadCategoriesByName(string searchQuery) 
        {
            List<ThreadCategoryDto> allCategories = threadCategoryService.SearchThreadCategoriesByName(searchQuery);

            List<CategoryIndexViewModel> categoryViewModels = allCategories.Select(tc => new CategoryIndexViewModel
            {
                CategoryName = tc.CategoryName,
                Description = tc.Description,
                Author = tc.CreatedBy,
                CategoryId = tc.Id
            }).ToList();

            CategoryViewModel model = new CategoryViewModel
            {
                Categories = categoryViewModels
            };

            return model;
        }
        public CategoryViewModel SearchThreadCategoriesByCreatedBy(string searchQuery)
        {
            List<ThreadCategoryDto> allCategories = threadCategoryService.SearchThreadCategoriesByCreatedBy(searchQuery);

            // Map ThreadCategoryDto to CategoryIndexViewModel
            List<CategoryIndexViewModel> categoryViewModels = allCategories.Select(tc => new CategoryIndexViewModel
            {
                CategoryName = tc.CategoryName,
                Description = tc.Description,
                Author = tc.CreatedBy,
                CategoryId = tc.Id
            }).ToList();

            // Construct the view model
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = categoryViewModels
            };

            return model;
        }
        public CategoryViewModel SearchThreadCategoriesByBoth(string searchQuery)
        {
            List<ThreadCategoryDto> allCategories = threadCategoryService.SearchThreadCategoriesByBoth(searchQuery);

            // Map ThreadCategoryDto to CategoryIndexViewModel
            List<CategoryIndexViewModel> categoryViewModels = allCategories.Select(tc => new CategoryIndexViewModel
            {
                CategoryName = tc.CategoryName,
                Description = tc.Description,
                Author = tc.CreatedBy,
                CategoryId = tc.Id
            }).ToList();

            // Construct the view model
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = categoryViewModels
            };

            return model;
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
					.Select(t => threadFacade.GetThreadTableViewModel(t)),
				Description = threadCategoryDto.Description
			};

			return model;
		}
        public CategoryThreadsViewModel NoResults(int categoryId)
        {
            ThreadCategoryDto threadCategoryDto = threadCategoryService.GetThreadCategoryById(categoryId);

            CategoryThreadsViewModel model = new CategoryThreadsViewModel()
            {
                CategoryName = threadCategoryDto.CategoryName,
                CategoryId = threadCategoryDto.Id,
               
                Description = threadCategoryDto.Description
            };

            return model;
        }
    }
}
