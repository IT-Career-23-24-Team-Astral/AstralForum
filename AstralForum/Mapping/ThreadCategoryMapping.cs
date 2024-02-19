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
            threadCategory.CreatedBy = threadCategoryDto.CreatedBy;
            threadCategory.CreatedOn = threadCategoryDto.CreatedOn;

            return threadCategory;
        }

        public static ThreadCategoryDto ToDto(this ThreadCategory threadCategory)
        {
            ThreadCategoryDto threadCategoryDto = new ThreadCategoryDto();

            threadCategoryDto.Id = threadCategory.Id;
            threadCategoryDto.CategoryName = threadCategory.CategoryName;
            threadCategoryDto.CreatedById = threadCategory.CreatedById;
            threadCategoryDto.CreatedBy = threadCategory.CreatedBy;
            threadCategoryDto.CreatedOn = threadCategory.CreatedOn;

            return threadCategoryDto;
        }
    }
}
