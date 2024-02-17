using AstralForum.Data.Entities.Comment;
using AstralForum.ServiceModels;

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

            return comment;
        }

        public static CommentDto ToDto(this Comment comment)
        {
            CommentDto commentDto = new CommentDto();

            commentDto.Id = comment.Id;
            commentDto.ThreadId = comment.ThreadId;
            commentDto.Text = comment.Text;
            commentDto.CommentId = comment.CommentId;
            commentDto.CreatedById = comment.CreatedById;
            commentDto.CreatedOn = comment.CreatedOn;

            return commentDto;
        }
    }
}
