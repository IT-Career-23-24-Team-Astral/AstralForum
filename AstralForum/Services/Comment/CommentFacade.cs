using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Comment
{
    public class CommentFacade : ICommentFacade
    {
        private readonly ICommentService _commentService;

        public CommentFacade(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<CommentDto> CreateComment(CommentAndReplyCreationFormModel commentAndReplyCreationFormModel, int threadId, User createdBy, int parentId = 0)
        {
            CommentDto commentDto = new CommentDto()
            {
                ThreadId = threadId,
                Text = commentAndReplyCreationFormModel.Text,
                ParentCommentId = parentId != 0 ? parentId : null,
                CreatedBy = createdBy.ToDto(),
                CreatedById = createdBy.Id
            };

            return await _commentService.AddComment(commentDto, createdBy);
        }
    }
}
