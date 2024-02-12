using AstralForum.Data.Entities.Comment;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Repositories;
using AstralForum.Repositories.Interfaces;
using AstralForum.ServiceModels;

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
            Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Create(comment)).ToDto();
        }
        public async Task<CommentDto> EditComment(CommentDto commentDto)
        {
            Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Edit(comment)).ToDto();
        }

        public async Task<CommentDto> GetAllCommentsByThreadId(CommentDto commentDto)
        {
            Comment comment = commentDto.ToEntity();
            return null;
            //return (await _commentRepository.GetCommentsByThreadId(comment)).ToDto();
        }

        public async Task<CommentDto> GetAllCommentsByCommentId(CommentDto commentDto)
        {
            Comment comment = commentDto.ToEntity();
            return null;
            //return (await _commentRepository.GetCommentsByCommentId(comment)).ToDto();
        }

        public async Task<CommentDto> DeleteComment(CommentDto commentDto)
        {
            Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Delete(comment)).ToDto();
        }

    }
}
