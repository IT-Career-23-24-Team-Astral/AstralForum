using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Reaction;
using AstralForum.Data.Entities.Tag;
using AstralForum.Models;
using AstralForum.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class TagRepository : CommonRepository<Tag>
    {
        private readonly ApplicationDbContext context;
        public TagRepository(ApplicationDbContext context) : base(context)
        {
            //this.context = context;
        }
        /*public async Task<List<Tag>> GetTagsByThreadId(int id)
        {
            Data.Entities.Thread.Thread thread = await context.Threads
                .Include(e => e.Tags)
                .FirstAsync(t => t.Id == id);
            return thread.Tags;
        }
        public async Task<List<Tag>> GetTagsByCommentId(int id)
        {
            Comment comment = await context.Comments
                .Include(e => e.Tags)
                .FirstAsync(t => t.Id == id);
            return comment.Tags;
        }
        public async Task<List<Tag>> GetTagsByTagId(int id)
        {
            Tag tag = await context.Tags
                .Include(e => e.Tags)
                .FirstAsync(p => p.Id == id);
            return tag.Tags;
        }*/

    }
}
       
