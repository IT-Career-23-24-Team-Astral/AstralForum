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
            thread.CreatedBy = threadDto.CreatedBy;
            thread.CreatedOn = threadDto.CreatedOn;
            thread.Comments = threadDto.Comments.Select(c => c.ToEntity()).ToList();
            thread.Reactions = threadDto.Reactions.Select(c => c.ToEntity()).ToList();
            thread.Attachments = threadDto.Attachments.Select(c => c.ToEntity()).ToList();

            return thread;
        }
        public static ThreadDto ToDto(this Data.Entities.Thread.Thread thread)
        {
            ThreadDto threadDto = new ThreadDto();

            threadDto.Id = thread.Id;
            threadDto.Title = thread.Title;
            threadDto.Text = thread.Text;
            threadDto.ImageUrl = thread.ImageUrl;
            threadDto.ThreadCategoryId = thread.ThreadCategoryId;
            threadDto.CreatedById = thread.CreatedById;
            threadDto.CreatedBy = thread.CreatedBy;
            threadDto.CreatedOn = thread.CreatedOn;
            threadDto.Comments = thread.Comments.Select(c => c.ToDto()).ToList();
            threadDto.Reactions = thread.Reactions.Select(c => c.ToDto()).ToList();
            threadDto.Attachments = thread.Attachments.Select(c => c.ToDto()).ToList();

            return threadDto;
        }
    }
}
