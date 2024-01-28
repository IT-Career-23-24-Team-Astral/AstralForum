using AstralForum.Data.Entities.Comments;
using AstralForum.Data.Entities.Users;
using AstralForum.Models.Comment;

namespace AstralForum.Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<CommentViewModel> GetComments(int id) => context.Comments.Where(c => c.Id == id).Select(x => new CommentViewModel()
        {
            Id = x.Id,
            UserId = x.UserId,
            PostId = x.PostId,
            Date = DateTime.Now,
            Text = x.Text,
            CommentId = x.CommentId
        }).ToList();

        public void AddComment(CommentViewModel model, string ownerName, User user) 
        {
            Comments coment = new Comments()
            {
                Id = model.Id,
                UserId = model.UserId,
                PostId = model.PostId,
                Date = DateTime.Now,
                Text = model.Text,
                CommentId = model.CommentId
            };
            context.Comments.Add(coment);
            context.SaveChanges();
        }
        public void Edit(Comments comment, CommentViewModel model)
        {
            comment.Text = model.Text;
            context.SaveChanges();
        }
        public void Delete(Comments comment)
        {
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
