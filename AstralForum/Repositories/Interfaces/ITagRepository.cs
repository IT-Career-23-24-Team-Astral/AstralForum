using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities;
using AstralForum.Models;
using AstralForum.Data.Entities.Tag;

namespace AstralForum.Repositories.Interfaces
{
    public interface ITagRepository
    {
        public Task<List<Tag>> GetTagsByThreadId(int id);
        public Task<List<Tag>> GetTagsByCommentId(int id);
        public Task<List<Tag>> GetTagsByTagId(int id);
    }
}
