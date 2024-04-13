﻿using AstralForum.Data.Entities;
using AstralForum.Mapping;
using AstralForum.Models;
using AstralForum.Models.Admin;
using AstralForum.Models.Comment;
using AstralForum.ServiceModels;
using AstralForum.Services.Thread;

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
        public async Task<HiddenCommentsViewModel> GetAllHiddenComments()
        {
            List<CommentDto> comments = await _commentService.GetAllHiddenComments();

            HiddenCommentsViewModel viewModel = new HiddenCommentsViewModel()
            {
                Comments = comments
            };

            return viewModel;
        }
        public async Task<HiddenCommentsViewModel> GetAllDeletedComments()
        {
            List<CommentDto> comments = await _commentService.GetAllDeletedComments();

            HiddenCommentsViewModel viewModel = new HiddenCommentsViewModel()
            {
                Comments = comments
            };

            return viewModel;
        }
    }
}
