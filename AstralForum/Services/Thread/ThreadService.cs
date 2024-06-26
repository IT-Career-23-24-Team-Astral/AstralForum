﻿
using AstralForum.Mapping;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AstralForum.Services.Thread
{
	public class ThreadService : IThreadService
	{
		private readonly IThreadRepository _threadRepository;

		public ThreadService(IThreadRepository threadRepository)
		{
			_threadRepository = threadRepository;
		}
		public async Task<ThreadDto> CreateThread(ThreadDto threadDto, User createdBy)
		{
			Data.Entities.Thread.Thread thread = threadDto.ToEntity();
			thread.CreatedBy = createdBy;
			return (await _threadRepository.Create(thread)).ToDto();
		}

		public int EditThread(int id, string newText, string newTitle)
		{
			return _threadRepository.EditThread(id, newText, newTitle);
		}

		public ThreadDto GetThreadById(int id)
		{
			Data.Entities.Thread.Thread thread = _threadRepository.GetThreadById(id);

			if (thread == default)
			{
				throw new ArgumentException($"Thread with id {id} not found");
			}

			ThreadDto threadDto = _threadRepository.GetThreadById(id).ToDto(includeCommentReplies: false);

			return threadDto;
		}

		public ThreadDto GetThreadByThreadIdWithReactions(int id)
		{
			return _threadRepository.GetAll()
				.Include(c => c.CreatedBy)
				.Include(c => c.Reactions)
					.ThenInclude(r => r.ReactionType)
				.Single(c => c.Id == id).ToDto(false, true, false, false, false, false, true);
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
        public async Task<List<ThreadDto>> GetAllHiddenThreads()
        {
            var hiddenThreads = await _threadRepository.GetAllHiddenThreads();

            var threadDtos = hiddenThreads.Select(thread => thread.ToDto(false, false, false, false, false, false)).ToList();

            return threadDtos;
        }
        public async Task<List<ThreadDto>> GetAllDeletedThreads()
        {
            var deletedThreads = await _threadRepository.GetAllDeletedThreads();

            var threadDtos = deletedThreads.Select(thread => thread.ToDto(false,false,false,false,false,false)).ToList();

            return threadDtos;
        }
        public ThreadDto HideThread(int id)
        {
			ThreadDto threadDto = _threadRepository.HideThread(id).ToDto(false, false, false, false, false, false, false);
            
            return threadDto;
        }
        public ThreadDto UnhideThread(int id)
        {
            ThreadDto threadDto = _threadRepository.UnhideThread(id).ToDto(false, false, false, false, false, false, false);
            return threadDto;
        }
        public ThreadDto DeleteThread(int id)
        {
            ThreadDto threadDto = _threadRepository.DeleteThread(id).ToDto(false, false, false, false, false, false, false);
            return threadDto;
        }
        public ThreadDto GetDeletedThreadBack(int id)
        {
            ThreadDto threadDto = _threadRepository.GetDeletedThreadBack(id).ToDto(false, false, false, false, false, false, false);
            return threadDto;
        }
        public void DeleteAllThreadsByUserId(int id)
        {
            _threadRepository.DeleteAllThreadsByUserId(id);
        }
	}
}