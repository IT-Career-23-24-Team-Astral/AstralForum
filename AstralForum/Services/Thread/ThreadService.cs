using AstralForum.Data.Entities.Comment;
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Data.Entities.Thread;

namespace AstralForum.Services.Thread
{
    public class ThreadService : IThreadService
	{
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

		public ThreadDto GetThreadById(int id)
		{
			ThreadDto threadDto = _threadRepository.GetThreadById(id).ToDto(includeCommentReplies: false);

			return threadDto;
		}
	}
}