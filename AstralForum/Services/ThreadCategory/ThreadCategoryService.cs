using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Services.ThreadCategory
{
    public class ThreadCategoryService : IThreadCategoryService
    {
        private readonly ThreadCategoryRepository _threadCategoryRepository;

        public ThreadCategoryService(ThreadCategoryRepository threadCategoryRepository)
        {
            _threadCategoryRepository = threadCategoryRepository;
        }

        public List<ThreadCategoryDto> GetAllThreadCategories()
        {
            return _threadCategoryRepository
                .GetAll()
                .Include(tc => tc.Threads)
                    .ThenInclude(t => t.CreatedBy)
                .Include(tc => tc.CreatedBy)
                .Select(tc => tc.ToDto(false))
                .ToList();
        }
        public List<ThreadCategoryDto> SearchThreadCategoriesByName(string searchQuery)
        {
            return _threadCategoryRepository
                .GetAll()
                .Include(tc => tc.Threads)
                    .ThenInclude(t => t.CreatedBy)
                .Include(tc => tc.CreatedBy)
                .AsEnumerable()
                .Where(tc =>
            tc.CategoryName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase)
        )
        .Select(tc => tc.ToDto(false))
        .ToList();
        }
        public List<ThreadCategoryDto> SearchThreadCategoriesByCreatedBy(string searchQuery)
        {
            return _threadCategoryRepository
                .GetAll()
                .Include(tc => tc.Threads)
                    .ThenInclude(t => t.CreatedBy)
                .Include(tc => tc.CreatedBy)
                .AsEnumerable()
                .Where(tc =>
            tc.CreatedBy.UserName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase)
        )
        .Select(tc => tc.ToDto(false))
        .ToList();
        }
        public List<ThreadCategoryDto> SearchThreadCategoriesByBoth(string searchQuery)
        {
            return _threadCategoryRepository
                .GetAll()
                .Include(tc => tc.Threads)
                    .ThenInclude(t => t.CreatedBy)
                .Include(tc => tc.CreatedBy)
                .AsEnumerable()
                .Where(tc =>
            tc.CategoryName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase) ||
            tc.CreatedBy.UserName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase)
        )
        .Select(tc => tc.ToDto(false))
        .ToList();
        }

        public ThreadCategoryDto GetThreadCategoryById(int id)
        {
            ThreadCategoryDto threadCategoryDto = _threadCategoryRepository.GetThreadCategoryById(id).ToDto();
            return threadCategoryDto;
        }
        
        public List<ThreadCategoryDto> SearchThreadByTitle(int id, string searchQuery)
        {
            var categories = _threadCategoryRepository
                .GetAll()
                .Include(tc => tc.Threads)
                    .ThenInclude(t => t.CreatedBy)
                .Include(tc => tc.CreatedBy)
                .Include(tc => tc.Threads)
                    .ThenInclude(t => t.Comments)
                        .ThenInclude(comment => comment.CreatedBy)
                .AsEnumerable()
                .Where(tc => tc.Id == id && searchQuery == null ||
							  tc.Threads.Any(t => t.Title.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase)))
                .Select(tc => tc.ToDto(false))
                .ToList();

            return categories;
        }




        public List<ThreadCategoryDto> SearchThreadByCreatedBy(int id, string searchQuery)
        {
            var categories = _threadCategoryRepository
                .GetAll()
                .Include(tc => tc.Threads)
                    .ThenInclude(t => t.CreatedBy)
                .Include(tc => tc.CreatedBy)
                .Include(tc => tc.Threads)
                    .ThenInclude(t => t.Comments)
                        .ThenInclude(comment => comment.CreatedBy)
                .AsEnumerable()
                .Where(tc => tc.Id == id && searchQuery == null || tc.Threads.Any(t => t.CreatedBy.UserName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase)))
                .Select(tc => tc.ToDto(false))
                .ToList();

            return categories;
        }



		public async Task<ThreadCategoryDto> CreateThreadCategory(ThreadCategoryDto threadCategoryDto, User createdBy)
        {
            Data.Entities.ThreadCategory.ThreadCategory category = threadCategoryDto.ToEntity();
            category.CreatedBy = createdBy;

            return (await _threadCategoryRepository.Create(category)).ToDto();
        }
        public async Task<ThreadCategoryDto> EditThreadCategory(ThreadCategoryDto threadCategoryDto, User createdBy)
        {
            Data.Entities.ThreadCategory.ThreadCategory category = threadCategoryDto.ToEntity();
            category.CreatedBy = createdBy;

            return (await _threadCategoryRepository.Edit(category)).ToDto();
        }
        public async Task<ThreadCategoryDto> DeleteThreadCategory(ThreadCategoryDto threadCategoryDto, User createdBy)
        {
            Data.Entities.ThreadCategory.ThreadCategory category = threadCategoryDto.ToEntity();

            category.CreatedBy = createdBy;

            return (await _threadCategoryRepository.Delete(category)).ToDto();
        }
    }
}