using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Thread;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
	public static class ThreadMapping
	{
		public static Data.Entities.Thread.Thread ToEntity(this ThreadDto threadDto)
		{
			Data.Entities.Thread.Thread thread = new Data.Entities.Thread.Thread();

            thread.Id = threadDto.Id;
            thread.Title = threadDto.Title;
            thread.Text = threadDto.Text;
            thread.ThreadCategoryId = threadDto.ThreadCategoryId;
            thread.CreatedById = threadDto.CreatedById;
            thread.CreatedBy = threadDto.CreatedBy.ToEntity();
            thread.CreatedOn = threadDto.CreatedOn;
            thread.Comments = threadDto.Comments.Select(c => c.ToEntity()).ToList();
            thread.Reactions = threadDto.Reactions.Select(c => c.ToEntity()).ToList();
            thread.Attachments = threadDto.Attachments.Select(c => c.ToEntity()).ToList();
            thread.IsHidden = threadDto.IsHidden;
            thread.IsDeleted = threadDto.IsDeleted;

            return thread;
        }
        public static ThreadDto ToDto(this Data.Entities.Thread.Thread thread, bool includeComments = true, bool includeReactions = true, bool includeAttachments = true,
        bool includeCommentReactions = true, bool includeCommentAttachments = true, bool includeCommentReplies = true, bool CreatedBy = true)
        {
            ThreadDto threadDto = new ThreadDto();

            threadDto.Id = thread.Id;
            threadDto.Title = thread.Title;
            threadDto.Text = thread.Text;
            threadDto.ThreadCategoryId = thread.ThreadCategoryId;
            threadDto.ThreadCategoryName = thread.ThreadCategory != null ? thread.ThreadCategory.CategoryName : "";
            threadDto.CreatedById = thread.CreatedById;
            if (CreatedBy == true)
            {
                threadDto.CreatedBy = thread.CreatedBy.ToDto();
            }
            threadDto.CreatedOn = thread.CreatedOn;
            // include only top level comments in the dto
            threadDto.Comments = includeComments ? thread.Comments.Select(c => c.ToDto(includeCommentReactions, includeCommentAttachments, includeCommentReplies)).Where(c => c.ParentCommentId == null).ToList() : new List<CommentDto>();
            threadDto.Reactions = includeReactions ? thread.Reactions.Select(r => r.ToDto()).ToList() : new List<ReactionDto>();
            threadDto.Attachments = includeAttachments ? thread.Attachments.Select(a => a.ToDto()).ToList() : new List<ThreadAttachmentDto>();
            threadDto.IsHidden = thread.IsHidden;
            threadDto.IsDeleted = thread.IsDeleted;

            return threadDto;
        }
    }
}