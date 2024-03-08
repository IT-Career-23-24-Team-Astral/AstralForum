using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Repositories;
using AstralForum.ServiceModels;
using AstralForum.Services.Comment;
<<<<<<<< HEAD:Services/Comment/CommentService.cs
using System.Xml.Linq;
========
>>>>>>>> 08aa2d3331c8e3f81d0a8537ca3cc50e586d735e:AstralForum/Services/Comment/CommentService.cs

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