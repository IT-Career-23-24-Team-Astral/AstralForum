
﻿using AstralForum.Data.Entities.Comment;
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

        public async Task<List<CommentDto>> GetAllCommentsByThreadId(int id)
        {
            List<Comment> comments = await _commentRepository.GetCommentsByThreadId(id);
            List<CommentDto> commentDtos = comments.Select(comment => comment.ToDto()).ToList();

            return commentDtos;
        }
        
        public async Task<List<CommentDto>> GetAllCommentsByCommentId(int id)
        {
            List<Comment> comments = await _commentRepository.GetCommentsByCommentId(id);
            List<CommentDto> commentDtos = comments.Select(comment => comment.ToDto()).ToList();

            return commentDtos;
        }
        public async Task<CommentDto> DeleteComment(CommentDto commentDto)
        {
            Comment comment = commentDto.ToEntity();

            return (await _commentRepository.Delete(comment)).ToDto();
        }

    }
}
