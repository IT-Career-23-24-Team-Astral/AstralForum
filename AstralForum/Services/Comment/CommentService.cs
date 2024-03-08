using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Services.Comment;

namespace AstralForum.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<CommentDto> AddComment(CommentDto commentDto)
        {
            Data.Entities.Comment.Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Create(comment)).ToDto();
        }
        public async Task<CommentDto> EditComment(CommentDto commentDto)
        {
            Data.Entities.Comment.Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Edit(comment)).ToDto();
        }

        public async Task<List<CommentDto>> GetAllCommentsByThreadId(int id)
        {
            List<Data.Entities.Comment.Comment> comments = await _commentRepository.GetCommentsByThreadId(id);
            List<CommentDto> commentDtos = comments.Select(comment => comment.ToDto()).ToList();

            return commentDtos;
        }

        public async Task<List<CommentDto>> GetAllCommentsByCommentId(int id)
        {
            List<Data.Entities.Comment.Comment> comments = await _commentRepository.GetCommentsByCommentId(id);
            List<CommentDto> commentDtos = comments.Select(comment => comment.ToDto()).ToList();

            return commentDtos;
        }
        public async Task<CommentDto> DeleteComment(CommentDto commentDto)
        {
            Data.Entities.Comment.Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Delete(comment)).ToDto();
        }

    }
}