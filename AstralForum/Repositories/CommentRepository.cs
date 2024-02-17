using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Thread;
using AstralForum.Models;
using AstralForum.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AstralForum.Repositories
{
    public class CommentRepository : CommonRepository<Comment> //, ICommentRepository
    {
        private readonly ApplicationDbContext context;
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            //this.context = context;
        }
        public async Task<List<Comment>> GetCommentsByThreadId(int id)
        {
            Data.Entities.Thread.Thread thread = await context.Threads
                .Include(e => e.Comments)
                .FirstAsync(p => p.ThreadCategoryId == id);
            return thread.Comments;
        }
        public async Task<List<Comment>> GetCommentsByCommentId(int id)
        {
            Comment comment = await context.Comments
                .Include(e => e.Comments)
                .FirstAsync(p => p.Id == id);
            return comment.Comments;
        }
        /*public IEnumerable<CommentModel> GetCommentsByThreadId(int id) => context.Comments.Where(c => c.ThreadId == id).Select(x => new CommentModel()
        {
            Id = x.Id,
            ThreadId = x.ThreadId,
            CreatedOn = x.CreatedOn,
            Text = x.Text,
            CommentId = (int)x.CommentId
        }).ToList();
        public IEnumerable<CommentModel> GetCommentsByCommentId(int id) => context.Comments.Where(c => c.CommentId == id).Select(x => new CommentModel()
        {
            Id = x.Id,
            ThreadId = x.ThreadId,
            CreatedOn = x.CreatedOn,
            Text = x.Text,
            CommentId = (int)x.CommentId
        }).ToList();

        /*public void AddComment(CommentModel model)
        {
            Comment coment = new Comment()
            {
                Id = model.Id,
                ThreadId = model.ThreadId,
                Text = model.Text,
                CommentId = model.CommentId,
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
