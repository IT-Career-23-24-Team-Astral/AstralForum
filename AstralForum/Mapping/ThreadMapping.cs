using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Thread;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
    public static class ThreadMapping
    {
        public static Post ToEntity(this ThreadDto threadDto)
        {
            Post thread = new Post();

            thread.Id = threadDto.Id;
            thread.Title = threadDto.Title;
            thread.Text = threadDto.Text;
            thread.ImageUrl = threadDto.ImageUrl;
            thread.ThreadCategory = threadDto.ThreadCategory;
            thread.CreatedById = threadDto.CreatedById;
            thread.CreatedOn = threadDto.CreatedOn;

            return thread;
        }

        public static ThreadDto ToDto(this Post thread)
        {
            ThreadDto threadDto = new ThreadDto();

            threadDto.Id = thread.Id;
            threadDto.Title = thread.Title;
            threadDto.Text = thread.Text;
            threadDto.ImageUrl = thread.ImageUrl;
            threadDto.ThreadCategory = thread.ThreadCategory;
            threadDto.CreatedById = thread.CreatedById;
            threadDto.CreatedOn = thread.CreatedOn;

            return threadDto;
        }
    }
}
