using AstralForum.Data.Entities;
using AstralForum.Models;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Comment
{
    public interface ICommentFacade
    {
        Task<CommentDto> CreateComment(CommentAndReplyCreationFormModel commentAndReplyCreationFormModel, int threadId, User createdBy, int parentId = 0);
    }
}
