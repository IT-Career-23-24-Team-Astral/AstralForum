
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Data.Entities.Thread;
using AstralForum.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Services.Thread
{
	public class ThreadService : IThreadService
	{
		private readonly ThreadRepository _threadRepository;

		public ThreadService(ThreadRepository threadRepository)
		{
			_threadRepository = threadRepository;
		}
		public async Task<ThreadDto> CreateThread(ThreadDto threadDto, User createdBy)
		{
			Data.Entities.Thread.Thread thread = threadDto.ToEntity();
			thread.CreatedBy = createdBy;
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
        public List<ThreadDto> SearchPostsByCreatedBy(int id, string searchQuery)
        {
            var threads = _threadRepository
                .GetAll()
                .Include(t => t.ThreadCategory)
                .Include(t => t.CreatedBy)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.CreatedBy)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Reactions)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Attachments)
                .Include(t => t.Reactions)
                .Include(t => t.Attachments)
				.AsEnumerable()
                .Where(t => t.Id == id && (searchQuery == null || t.Comments.Any(c => c.CreatedBy.UserName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase))))
                .Select(tc => tc.ToDto(includeCommentReplies: false))
                .ToList();

            return threads;
        }
		public List<ThreadDto> SearchPostsByText(int id, string searchQuery)
		{
			var threads = _threadRepository
				.GetAll()
				.Include(t => t.ThreadCategory)
				.Include(t => t.CreatedBy)
				.Include(t => t.Comments)
					.ThenInclude(c => c.CreatedBy)
				.Include(t => t.Comments)
					.ThenInclude(c => c.Reactions)
				.Include(t => t.Comments)
					.ThenInclude(c => c.Attachments)
				.Include(t => t.Reactions)
				.Include(t => t.Attachments)
				.AsEnumerable()
				.Where(t => t.Id == id && (searchQuery == null ||
					t.Comments.Any(c => c.Text.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase))))
				.Select(tc => tc.ToDto(includeCommentReplies: false))
				.ToList();

			return threads;
		}
		public List<ThreadDto> SearchPostsByBoth(int id, string searchQuery)
		{
			var threads = _threadRepository
				.GetAll()
				.Include(t => t.ThreadCategory)
				.Include(t => t.CreatedBy)
				.Include(t => t.Comments)
					.ThenInclude(c => c.CreatedBy)
				.Include(t => t.Comments)
					.ThenInclude(c => c.Reactions)
				.Include(t => t.Comments)
					.ThenInclude(c => c.Attachments)
				.Include(t => t.Reactions)
				.Include(t => t.Attachments)
				.AsEnumerable()
				.Where(t => t.Id == id && (searchQuery == null ||
					t.Comments.Any(c => c.Text.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase)) ||
					t.CreatedBy.UserName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase)))
				.Select(tc => tc.ToDto(includeCommentReplies: false))
				.ToList();
			return threads;
		}
	}
}