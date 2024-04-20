using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Models.Admin;
using AstralForum.Models.Comment;
using AstralForum.ServiceModels;
using AstralForum.Services.Thread;

namespace AstralForum.Services.Comment
{
    public class CommentFacade : ICommentFacade
    {
        private readonly ICommentService _commentService;
        private readonly ICloudinaryService _cloudinaryService;

        public CommentFacade(ICommentService commentService, ICloudinaryService cloudinaryService)
		{
			_commentService = commentService;
			_cloudinaryService = cloudinaryService;
		}

        public async Task<CommentDto> CreateComment(CommentAndReplyCreationFormModel commentAndReplyCreationFormModel, int threadId, User createdBy, int parentId = 0)
        {
            CommentDto commentDto = new CommentDto()
            {
                ThreadId = threadId,
                Text = commentAndReplyCreationFormModel.Text,
                ParentCommentId = parentId != 0 ? parentId : null,
                Attachments = commentAndReplyCreationFormModel.Attachments != null ? commentAndReplyCreationFormModel.Attachments.Select(a => new CommentAttachmentDto()
				{
					CreatedBy = createdBy.ToDto(),
					CreatedById = createdBy.Id,
					AttachmentUrl = _cloudinaryService.UploadFile(a).SecureUrl.AbsoluteUri,
                    FileName = a.FileName
				}).ToList() : new List<CommentAttachmentDto>(),
				CreatedBy = createdBy.ToDto(),
                CreatedById = createdBy.Id
            };

            return await _commentService.AddComment(commentDto, createdBy);
        }
        public async Task<HiddenCommentsViewModel> GetAllHiddenComments()
        {
            List<CommentDto> comments = await _commentService.GetAllHiddenComments();

            HiddenCommentsViewModel viewModel = new HiddenCommentsViewModel()
            {
                Comments = comments
            };

            return viewModel;
        }
        public async Task<HiddenCommentsViewModel> GetAllDeletedComments()
        {
            List<CommentDto> comments = await _commentService.GetAllDeletedComments();

            HiddenCommentsViewModel viewModel = new HiddenCommentsViewModel()
            {
                Comments = comments
            };

            return viewModel;
        }
    }
}
