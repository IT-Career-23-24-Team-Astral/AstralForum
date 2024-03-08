﻿using AstralForum.Data.Entities.Comment;
using AstralForum.ServiceModels;

namespace AstralForum.Services.Comment
{
    public interface ICommentService
    {
        Task<CommentDto> AddComment(CommentDto model);
        Task<CommentDto> EditComment(CommentDto commentDto);
        Task<List<CommentDto>> GetAllCommentsByThreadId(int id);
        Task<List<CommentDto>> GetAllCommentsByCommentId(int id);
        Task<CommentDto> DeleteComment(CommentDto commentDto);
    }
}