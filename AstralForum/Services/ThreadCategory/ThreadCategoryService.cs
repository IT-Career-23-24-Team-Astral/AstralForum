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
                .Include(tc => tc.CreatedBy)
                .Select(tc => tc.ToDto())
                .ToList();
        }

        public ThreadCategoryDto GetThreadCategoryById(int id)
        {
            ThreadCategoryDto threadCategoryDto = _threadCategoryRepository.GetThreadCategoryById(id).ToDto();
            return threadCategoryDto;
            //return _threadCategoryRepository.GetThreadCategoryById(id).ToDto();
        }

        public async Task<ThreadCategoryDto> CreateThreadCategory(ThreadCategoryDto threadCategoryDto)
        {
            Data.Entities.ThreadCategory.ThreadCategory category = threadCategoryDto.ToEntity();

            return (await _threadCategoryRepository.Create(category)).ToDto();
        }
        public async Task<ThreadCategoryDto> EditThreadCategory(ThreadCategoryDto threadCategoryDto)
        {
            Data.Entities.ThreadCategory.ThreadCategory category = threadCategoryDto.ToEntity();

            return (await _threadCategoryRepository.Edit(category)).ToDto();
        }
        public async Task<ThreadCategoryDto> DeleteThreadCategory(ThreadCategoryDto threadCategoryDto)
        {
            Data.Entities.ThreadCategory.ThreadCategory category = threadCategoryDto.ToEntity();
            return (await _threadCategoryRepository.Delete(category)).ToDto();
        }
    }
}