using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Models.Thread;
using AstralForum.Repositories;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Thread
{
    public class ThreadFacade : IThreadFacade
    {
        private readonly IThreadService threadService;
        private readonly ICloudinaryService cloudinaryService;

        public ThreadFacade(IThreadService threadService, ICloudinaryService cloudinaryService)
        {
            this.threadService = threadService;
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
    }
}
