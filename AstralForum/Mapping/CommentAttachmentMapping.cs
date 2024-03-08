using AstralForum.Data.Entities.Comment;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
    public static class CommentAttachmentMapping
    {
        public static CommentAttachment ToEntity(this CommentAttachmentDto commentAttachmentDto)
        {
            CommentAttachment commentAttachment = new CommentAttachment();

            commentAttachment.Id = commentAttachmentDto.Id;
            commentAttachment.CommentId = commentAttachmentDto.CommentId;
            commentAttachment.Comment = commentAttachmentDto.Comment;
            commentAttachment.AttachmentUrl = commentAttachmentDto.AttachmentUrl;

            return commentAttachment;
        }

        public static CommentAttachmentDto ToDto(this CommentAttachment commentAttachment)
        {
            CommentAttachmentDto commentAttachmentDto = new CommentAttachmentDto();

            commentAttachmentDto.Id = commentAttachment.Id;
            commentAttachmentDto.CommentId = commentAttachment.CommentId;
            commentAttachmentDto.Comment = commentAttachment.Comment;
            commentAttachmentDto.AttachmentUrl = commentAttachment.AttachmentUrl;

            return commentAttachmentDto;
        }
    }
}
