using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models.Admin;
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
        private readonly ICloudinaryService cloudinaryService;
        private readonly ICommentService commentService;

        public ThreadFacade(IThreadService threadService, ICommentService commentService, ICloudinaryService cloudinaryService)
        {
            this.threadService = threadService;
            this.commentService = commentService;
            this.cloudinaryService = cloudinaryService;
        }

        public ThreadTableViewModel GetThreadTableViewModel(ThreadDto threadDto)
        {
            ThreadTableViewModel model = new ThreadTableViewModel()
            {
                Id = threadDto.Id,
                Title = threadDto.Title,
                DateOfCreation = threadDto.CreatedOn,
                Author = threadDto.CreatedBy,
                LastComment = threadDto.Comments.OrderByDescending(c => c.CreatedOn).FirstOrDefault(),
                IsHidden = threadDto.IsHidden,
            };

            return model;
        }
     
        public async Task<ThreadDto> CreateThread(ThreadCreationFormModel threadForm, User createdBy)
        {
            ThreadDto threadDto = new ThreadDto()
            {
                Title = threadForm.Title,
                Text = threadForm.Text,
                ThreadCategoryId = threadForm.CategoryId,
                CreatedBy = createdBy.ToDto(),
                Attachments = threadForm.Attachments != null ? threadForm.Attachments.Select(a => new ThreadAttachmentDto()
                {
                    CreatedBy = createdBy.ToDto(),
                    CreatedById = createdBy.Id,
                    AttachmentUrl = cloudinaryService.UploadFile(a).SecureUrl.AbsoluteUri,
                    FileName = a.FileName
                }).ToList() : new List<ThreadAttachmentDto>(),
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

		public async Task<HiddenThreadsViewModel> GetAllHiddenThreads()
        {
            List<ThreadDto> threads = await threadService.GetAllHiddenThreads();

            HiddenThreadsViewModel viewModel = new HiddenThreadsViewModel()
            {
                Threads = threads
            };

            return viewModel;
        }
        public async Task<HiddenThreadsViewModel> GetAllDeletedThreads()
        {
            List<ThreadDto> threads = await threadService.GetAllDeletedThreads();

            HiddenThreadsViewModel viewModel = new HiddenThreadsViewModel()
            {
                Threads = threads
            };

            return viewModel;
        }
	}
}
