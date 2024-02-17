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
            thread.CreatedOn = threadDto.CreatedOn;

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
            threadDto.CreatedOn = thread.CreatedOn;

            return threadDto;
        }
    }
}
