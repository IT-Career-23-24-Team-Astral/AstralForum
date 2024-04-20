using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Models.Comment;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Comment
{
    public interface ICommentService
    {
        Task<CommentDto> AddComment(CommentDto model, User createdBy);
        Task<CommentDto> EditComment(CommentDto commentDto);
        CommentDto GetCommentByCommentIdWithReactions(int id);
        Task<List<CommentDto>> GetAllCommentsByThreadId(int id);
        Task<List<CommentDto>> GetAllRepliesByCommentId(int id);
        Task<CommentDto> DeleteComment(CommentDto commentDto);

        CommentTableViewModel GetCommentTableViewModel(CommentDto commentDto);
        Task<List<CommentDto>> GetAllHiddenComments();
        Task<List<CommentDto>> GetAllDeletedComments();
        CommentDto HideComment(int id);
        CommentDto UnhideComment(int id);
        CommentDto DeleteComment(int id);
        CommentDto GetDeletedCommentBack(int id);
        void DeleteAllCommentsByUserId(int userId);
    }
}