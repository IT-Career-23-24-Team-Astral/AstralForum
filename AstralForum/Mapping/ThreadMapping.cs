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
            thread.ImageUrl = threadDto.ImageUrl;
            thread.ThreadCategoryId = threadDto.ThreadCategoryId;
            thread.CreatedById = threadDto.CreatedById;
            thread.CreatedBy = threadDto.CreatedBy.ToEntity();
            thread.CreatedOn = threadDto.CreatedOn;
            thread.Comments = threadDto.Comments.Select(c => c.ToEntity()).ToList();
            thread.Reactions = threadDto.Reactions.Select(c => c.ToEntity()).ToList();
            thread.Attachments = threadDto.Attachments.Select(c => c.ToEntity()).ToList();

            return thread;
        }
        public static ThreadDto ToDto(this Data.Entities.Thread.Thread thread, bool includeComments = true, bool includeReactions = true, bool includeAttachments = true)
        {
            ThreadDto threadDto = new ThreadDto();

            threadDto.Id = thread.Id;
            threadDto.Title = thread.Title;
            threadDto.Text = thread.Text;
            threadDto.ImageUrl = thread.ImageUrl;
            threadDto.ThreadCategoryId = thread.ThreadCategoryId;
            threadDto.CreatedById = thread.CreatedById;
            threadDto.CreatedBy = thread.CreatedBy.ToDto();
            threadDto.CreatedOn = thread.CreatedOn;
            threadDto.Comments = includeComments ? thread.Comments.Select(c => c.ToDto()).ToList() : null;
            threadDto.Reactions = includeReactions ? thread.Reactions.Select(r => r.ToDto()).ToList() : null;
            threadDto.Attachments = includeAttachments ? thread.Attachments.Select(a => a.ToDto()).ToList() : null;

            return threadDto;
        }
    }
}
