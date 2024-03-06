﻿using AstralForum.Data.Entities.Comment;
using AstralForum.ServiceModels;
using AstralForum.Mapping;

namespace AstralForum.Mapping
{
    public static class CommentMapping
    {
        public static Comment ToEntity(this CommentDto commentDto)
        {
            Comment comment = new Comment();

            comment.Id = commentDto.Id;
            comment.ThreadId = commentDto.ThreadId;
            comment.Text = commentDto.Text;
            comment.CommentId = commentDto.CommentId;
            comment.CreatedById = commentDto.CreatedById;
            comment.CreatedOn = commentDto.CreatedOn;
            comment.Comments = commentDto.Comments.Select(c => c.ToEntity()).ToList();
            comment.Reactions = commentDto.Reactions.Select(c => c.ToEntity()).ToList();
            comment.Attachments = commentDto.Attachments.Select(c => c.ToEntity()).ToList();

            return comment;
        }
        public static CommentDto ToDto(this Comment comment, bool includeReactions = true, bool includeReplies = true, bool includeAttachments = true)
        {
            CommentDto commentDto = new CommentDto();

            commentDto.Id = comment.Id;
            commentDto.ThreadId = comment.ThreadId;
            commentDto.Text = comment.Text;
            commentDto.CommentId = comment.CommentId;
            commentDto.CreatedById = comment.CreatedById;
            commentDto.CreatedOn = comment.CreatedOn;
            commentDto.Comments = includeReplies ? comment.Comments.Select(c => c.ToDto()).ToList() : null;
            commentDto.Reactions = includeReactions ? comment.Reactions.Select(c => c.ToDto()).ToList() : null;
            commentDto.Attachments = includeAttachments ? comment.Attachments.Select(c => c.ToDto()).ToList() : null;

            return commentDto;
        }
    }
}
