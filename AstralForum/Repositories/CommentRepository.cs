using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Models;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class CommentRepository : CommonRepository<Comment> //, ICommentRepository
    {
        private readonly ApplicationDbContext context;
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            //this.context = context;
        }
        public IEnumerable<CommentModel> GetCommentsByThreadId(int id) => context.Comments.Where(c => c.ThreadId == id).Select(x => new CommentModel()
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
