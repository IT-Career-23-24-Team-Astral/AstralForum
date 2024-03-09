using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class CommentRepository : CommonRepository<Comment>
    {
        public CommentRepository(ApplicationDbContext context) : base(context) { }
        public async Task<List<Comment>> GetCommentsByThreadId(int id)
        {
            Data.Entities.Thread.Thread thread = await context.Threads
                .Include(e => e.Comments)
                .FirstAsync(p => p.ThreadCategoryId == id);
            return thread.Comments;
        }
        public async Task<List<Comment>> GetRepliesByCommentId(int id)
        {
            Comment comment = await context.Comments
                .Include(c => c.Comments)
                    .ThenInclude(cc => cc.CreatedBy)
                .Include(c => c.Comments)
                    .ThenInclude(cc => cc.Attachments)
                .Include(c => c.Comments)
                    .ThenInclude(cc => cc.Reactions)
                .FirstAsync(c => c.Id == id);
            return comment.Comments;
        }
        /*public IEnumerable<CommentModel> GetCommentsByThreadId(int id) => context.Comments.Where(c => c.ThreadId == id).Select(x => new CommentModel()
        {
            Id = x.Id,
            ThreadId = x.ThreadId,
            CreatedOn = x.CreatedOn,
            Text = x.Text,
            ParentCommentId = (int)x.ParentCommentId
        }).ToList();
        public IEnumerable<CommentModel> GetCommentsByCommentId(int id) => context.Comments.Where(c => c.ParentCommentId == id).Select(x => new CommentModel()
        {
            Id = x.Id,
            ThreadId = x.ThreadId,
            CreatedOn = x.CreatedOn,
            Text = x.Text,
            ParentCommentId = (int)x.ParentCommentId
        }).ToList();

        /*public void AddComment(CommentModel model)
        {
            Comment coment = new Comment()
            {
                Id = model.Id,
                ThreadId = model.ThreadId,
                Text = model.Text,
                ParentCommentId = model.ParentCommentId,
                CreatedById = model.CreatedById
            };
            context.Comments.Add(coment);
            context.SaveChanges();
        }
        /*public void Edit(Comment comment, CommentModel model)
        {
            comment.Text = model.Text;
            context.Comments.Update(comment);
            context.SaveChanges();
        }
        public void Delete(Comment comment)
        {
            context.Comments.Remove(comment);
            context.SaveChanges();
        }*/
    }
}