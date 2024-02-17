using AstralForum.Data.Entities.Comment;
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.Repositories.Interfaces;
using AstralForum.ServiceModels;
using AstralForum.Data.Entities.Thread;

namespace AstralForum.Services
{
    public class ThreadService : IThreadService
    {
<<<<<<< HEAD

=======
        private readonly ThreadRepository _threadRepository;

        public ThreadService(ThreadRepository threadRepository)
        {
            _threadRepository = threadRepository;
        }
        public async Task<ThreadDto> CreateThread(ThreadDto threadDto)
        {
            Data.Entities.Thread.Thread thread = threadDto.ToEntity();
            return (await _threadRepository.Create(thread)).ToDto();
        }

        public async Task<ThreadDto> DeleteThread(ThreadDto threadDto)
        {
            Data.Entities.Thread.Thread thread = threadDto.ToEntity();
            return (await _threadRepository.Delete(thread)).ToDto();
        }

        public async Task<ThreadDto> EditThread(ThreadDto threadDto)
        {
            Data.Entities.Thread.Thread thread = threadDto.ToEntity();
            return (await _threadRepository.Edit(thread)).ToDto();
        }

        public async Task<List<ThreadDto>> GetAllThreadsByThreadCategoryId(int id)
        {
            List<Data.Entities.Thread.Thread> threads = await _threadRepository.GetThreadsByThreadCategoryId(id);
            List<ThreadDto> threadDtos = threads.Select(thread => thread.ToDto()).ToList();

            return threadDtos;
        }
>>>>>>> demo
    }
}
