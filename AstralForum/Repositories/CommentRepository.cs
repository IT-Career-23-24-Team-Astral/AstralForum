using AstralForum.Data.Entities.Comment;
using AstralForum.Models.Comment;
using AstralForum.Repositories.Interfaces;

namespace AstralForum.Repositories
{
    public class CommentRepository : CommonRepository<Comment>, ICommentRepository
    {
        private ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public IEnumerable<CommentViewModel> GetComments(int id) => context.Comments.Where(c => c.Id == id).Select(x => new CommentViewModel()
        {
            Id = x.Id,
            PostId = x.PostId,
            Date = DateTime.Now,
            Text = x.Text,
            CommentId = x.CommentId
        }).ToList();

        public void AddComment(CommentViewModel model, string ownerName)
        {
            Comment coment = new Comment()
            {
                Id = model.Id,
                PostId = model.PostId,
                Text = model.Text,
                CommentId = model.CommentId
            };
            context.Comments.Add(coment);
            context.SaveChanges();
        }
        public void Edit(Comment comment, CommentViewModel model)
        {
            comment.Text = model.Text;
            context.SaveChanges();
        }
        public void Delete(Comment comment)
        {
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
