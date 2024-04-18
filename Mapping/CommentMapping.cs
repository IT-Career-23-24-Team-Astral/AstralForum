using AstralForum.Data.Entities.Comment;
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
            comment.CommentId = commentDto.ParentCommentId;
            comment.CreatedById = commentDto.CreatedById;
            comment.CreatedOn = commentDto.CreatedOn;
            comment.Comments = commentDto.Comments.Select(c => c.ToEntity()).ToList();
            comment.Reactions = commentDto.Reactions.Select(r => r.ToEntity()).ToList();
            comment.Attachments = commentDto.Attachments.Select(a => a.ToEntity()).ToList();

            return comment;
        }
        public static CommentDto ToDto(this Comment comment, bool includeReactions = true, bool includeAttachments = true, bool includeReplies = true)
        {
            CommentDto commentDto = new CommentDto();

            commentDto.Id = comment.Id;
            commentDto.ThreadId = comment.ThreadId;
            commentDto.Text = comment.Text;
            commentDto.ParentCommentId = comment.CommentId;
            commentDto.CreatedById = comment.CreatedById;
            commentDto.CreatedBy = comment.CreatedBy.ToDto();
            commentDto.CreatedOn = comment.CreatedOn;
            commentDto.Comments = includeReplies ? comment.Comments.Select(c => c.ToDto()).ToList() : new List<CommentDto>();
            commentDto.Reactions = includeReactions ? comment.Reactions.Select(r => r.ToDto()).ToList() : new List<CommentReactionDto>();
            commentDto.Attachments = includeAttachments ? comment.Attachments.Select(a => a.ToDto()).ToList() : new List<CommentAttachmentDto>();

            return commentDto;
        }
    }
}