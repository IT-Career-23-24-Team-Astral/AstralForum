using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.ServiceModels;

namespace AstralForum.Services.ThreadCategory
{
    public class ThreadCategoryService : IThreadCategoryService
    {
        private readonly ThreadCategoryRepository _threadCategoryRepository;

        public ThreadCategoryService(ThreadCategoryRepository threadCategoryRepository)
        {
            _threadCategoryRepository = threadCategoryRepository;
        }

        public IQueryable<ThreadCategoryDto> GetAllThreadCategories()
        {
            return (IQueryable<ThreadCategoryDto>)_threadCategoryRepository.GetAll();
        }

        public ThreadCategoryDto GetThreadCategoryById(int id)
        {
            return _threadCategoryRepository.GetThreadCategoryById(id).ToDto();
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
        public async Task<ThreadCategoryDto> DeleteThread(ThreadCategoryDto threadCategoryDto)
        {
            Data.Entities.ThreadCategory.ThreadCategory category = threadCategoryDto.ToEntity();
            return (await _threadCategoryRepository.Delete(category)).ToDto();
        }
    }
}
