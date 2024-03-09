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

        public ThreadCategoryDto GetThreadCategoryById(int id)
        {
            ThreadCategoryDto threadCategoryDto = _threadCategoryRepository.GetThreadCategoryById(id).ToDto();
            return threadCategoryDto;
            //return _threadCategoryRepository.GetThreadCategoryById(id).ToDto();
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