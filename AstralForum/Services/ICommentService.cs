using AstralForum.Data.Entities.Comment;
using AstralForum.ServiceModels;

namespace AstralForum.Services
{
    public interface ICommentService
    {
        Task<CommentDto> AddComment(CommentDto model);
        Task<CommentDto> EditComment(CommentDto commentDto);
        Task<CommentDto> GetAllCommentsByThreadId(CommentDto commentDto);
        Task<CommentDto> GetAllCommentsByCommentId(CommentDto commentDto);
        Task<CommentDto> DeleteComment(CommentDto commentDto);
    }
}
