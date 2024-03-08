using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.ThreadCategory;
using AstralForum.ServiceModels;

namespace AstralForum.Mapping
{
    public static class ThreadCategoryMapping
    {
        public static ThreadCategory ToEntity(this ThreadCategoryDto threadCategoryDto)
        {
            ThreadCategory threadCategory = new ThreadCategory();

            threadCategory.Id = threadCategoryDto.Id;
            threadCategory.CategoryName = threadCategoryDto.CategoryName;
            threadCategory.CreatedById = threadCategoryDto.CreatedById;
            threadCategory.CreatedBy = threadCategoryDto.CreatedBy.ToEntity();
            threadCategory.CreatedOn = threadCategoryDto.CreatedOn;

            return threadCategory;
        }

        public static ThreadCategoryDto ToDto(this ThreadCategory threadCategory)
        {
            ThreadCategoryDto threadCategoryDto = new ThreadCategoryDto();

            threadCategoryDto.Id = threadCategory.Id;
            threadCategoryDto.CategoryName = threadCategory.CategoryName;
            // only have to include the comments in the threads of a category
            threadCategoryDto.Threads = threadCategory.Threads.Select(t => t.ToDto(true, false, false)).ToList();
            threadCategoryDto.CreatedById = threadCategory.CreatedById;
            threadCategoryDto.CreatedBy = threadCategory.CreatedBy.ToDto();
            threadCategoryDto.CreatedOn = threadCategory.CreatedOn;

            return threadCategoryDto;
        }
    }
}
