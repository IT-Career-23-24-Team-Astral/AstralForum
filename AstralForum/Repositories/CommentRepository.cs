using AstralForum.Data.Entities;
using AstralForum.Data.Entities.Comment;
using AstralForum.Models.Comment;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class CommentRepository : CommonRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public IEnumerable<CommentViewModel> GetCommentsByThreadId(int id) => context.Comments.Where(c => c.ThreadId == id).Select(x => new CommentViewModel()
        {
            Id = x.Id,
            ThreadId = x.ThreadId,
            Date = DateTime.Now,
            Text = x.Text,
            CommentId = x.CommentId
        }).ToList();
        public IEnumerable<CommentViewModel> GetCommentsByCommentId(int id) => context.Comments.Where(c => c.CommentId == id).Select(x => new CommentViewModel()
        {
            Id = x.Id,
            ThreadId = x.ThreadId,
            Date = DateTime.Now,
            Text = x.Text,
            CommentId = x.CommentId
        }).ToList();

        public void AddComment(CommentViewModel model, User id)
        {
            Comment coment = new Comment()
            {
                Id = model.Id,
                ThreadId = model.ThreadId,
                Text = model.Text,
                CommentId = model.CommentId,
                CreatedBy = id
            };
            context.Comments.Add(coment);
            context.SaveChanges();
        }
        public void Edit(Comment comment, CommentViewModel model)
        {
            comment.Text = model.Text;
            context.Comments.Update(comment);
            context.SaveChanges();
        }
        public void Delete(Comment comment)
        {
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
