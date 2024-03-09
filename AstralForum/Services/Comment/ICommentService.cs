using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Comment
{
    public interface ICommentService
    {
        Task<CommentDto> AddComment(CommentDto model, User createdBy);
        Task<CommentDto> EditComment(CommentDto commentDto);
        Task<List<CommentDto>> GetAllCommentsByThreadId(int id);
        Task<List<CommentDto>> GetAllRepliesByCommentId(int id);
        Task<CommentDto> DeleteComment(CommentDto commentDto);
    }
}