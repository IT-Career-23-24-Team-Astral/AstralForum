using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models.Admin;
using AstralForum.Models.Thread;
using AstralForum.Repositories;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Thread
{
    public class ThreadFacade : IThreadFacade
    {
        private readonly IThreadService threadService;

        public ThreadFacade(IThreadService threadService)
        {
            this.threadService = threadService;
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
