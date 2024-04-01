using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Models.Thread;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Services.Comment;
using AstralForum.Services.ThreadCategory;

namespace AstralForum.Services.Thread
{
    public class ThreadFacade : IThreadFacade
    {
        private readonly IThreadService threadService;
        private readonly ICommentService commentService;

        public ThreadFacade(IThreadService threadService, ICommentService commentService)
        {
            this.threadService = threadService;
            this.commentService = commentService;
        }

        public ThreadTableViewModel GetThreadTableViewModel(ThreadDto threadDto)
        {
            ThreadTableViewModel model = new ThreadTableViewModel()
            {
                Id = threadDto.Id,
                Title = threadDto.Title,
                DateOfCreation = threadDto.CreatedOn,
                Author = threadDto.CreatedBy,
                LastComment = threadDto.Comments.OrderByDescending(c => c.CreatedOn).FirstOrDefault()
            };

            return model;
        }
     
        public async Task<ThreadDto> CreateThread(ThreadCreationFormModel threadForm, User createdBy)
        {
            // TODO: handle attachment upload and setting urls in the DTO

            ThreadDto threadDto = new ThreadDto()
            {
                Title = threadForm.Title,
                Text = threadForm.Text,
                ThreadCategoryId = threadForm.CategoryId,
                CreatedBy = createdBy.ToDto()
            };

            return await threadService.CreateThread(threadDto, createdBy);
        }
		public ThreadDto SearchPostsByCreatedBy(int id, string searchQuery)
		{
			List<ThreadDto> allThreads = threadService.SearchPostsByCreatedBy(id, searchQuery);

			if (allThreads == null || !allThreads.Any())
			{
				return null;
			}
			else if (searchQuery == null)
			{
				return null;
			}
			else
			{
				ThreadDto selectedThread = allThreads.First();

				
				var filteredComments = selectedThread.Comments
					.Where(c => c.CreatedBy.UserName != null &&
								searchQuery != null &&
								c.CreatedBy.UserName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase))
					.ToList();

				ThreadDto model = new ThreadDto
				{
					Id = selectedThread.Id,
					Title = selectedThread.Title,
					Text = selectedThread.Text,
					ThreadCategoryId = selectedThread.ThreadCategoryId,
					ThreadCategoryName = selectedThread.ThreadCategoryName,
					Comments = filteredComments,
					Reactions = selectedThread.Reactions,
					Attachments = selectedThread.Attachments,
					CreatedBy = selectedThread.CreatedBy
				};

				return model;
			}
		}
		public ThreadDto SearchPostsByText(int id, string searchQuery)
		{
			List<ThreadDto> allThreads = threadService.SearchPostsByText(id, searchQuery);

			if (allThreads == null || !allThreads.Any())
			{
				return null;
			}
			else if (searchQuery == null)
			{ 
				return null;
			}
			else
			{
				ThreadDto selectedThread = allThreads.First();


				var filteredComments = selectedThread.Comments
					.Where(c => c.Text.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase))
					.ToList();

				ThreadDto model = new ThreadDto
				{
					Id = selectedThread.Id,
					Title = selectedThread.Title,
					Text = selectedThread.Text,
					ThreadCategoryId = selectedThread.ThreadCategoryId,
					ThreadCategoryName = selectedThread.ThreadCategoryName,
					Comments = filteredComments,
					Reactions = selectedThread.Reactions,
					Attachments = selectedThread.Attachments,
					CreatedBy = selectedThread.CreatedBy
				};

				return model;
			}
		}
		public ThreadDto SearchPostsByBoth(int id, string searchQuery)
		{
			List<ThreadDto> allThreads = threadService.SearchPostsByBoth(id, searchQuery);

			if (allThreads == null || !allThreads.Any())
			{
				return null;
			}
			else if (searchQuery == null)
			{
				return null;
			}
			else
			{
				ThreadDto selectedThread = allThreads.First();


				var filteredComments = selectedThread.Comments
					.Where(c => c.Text.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase) ||
								c.CreatedBy.UserName.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase))
					.ToList();

				ThreadDto model = new ThreadDto
				{
					Id = selectedThread.Id,
					Title = selectedThread.Title,
					Text = selectedThread.Text,
					ThreadCategoryId = selectedThread.ThreadCategoryId,
					ThreadCategoryName = selectedThread.ThreadCategoryName,
					Comments = filteredComments,
					Reactions = selectedThread.Reactions,
					Attachments = selectedThread.Attachments,
					CreatedBy = selectedThread.CreatedBy
				};

				return model;
			}
		}
		public ThreadDto NoResultsThread(int id)
        {
            ThreadDto threadDto = threadService.GetThreadById(id);
            ThreadDto model = new ThreadDto
            {   
                Id = threadDto.Id,
                Title = threadDto.Title,
                Text = threadDto.Text,
                ThreadCategoryName = threadDto.ThreadCategoryName,
                CreatedBy = threadDto.CreatedBy,
				CreatedOn = threadDto.CreatedOn
            };
            return model;
        }



	}
}
