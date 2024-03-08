using AstralForum.ServiceModels;

namespace AstralForum.Services
{
    public interface ITagService
    {
        public Task<List<TagDto>> GetAllTagsByThreadId(int id);
        public Task<List<TagDto>> GetAllTagsByCommentId(int id);
        public Task<List<TagDto>> GetAllTagsByTagId(int id);
    }
}
