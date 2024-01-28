using AstralForum.Data.Entities.Comments;
using AstralForum.Models.Comment;

namespace AstralForum.Services
{
    public class CommentService
    {
        ApplicationDbContext _context;

        public IEnumerable<CommentViewModel> GetComments(int id) => _context.Comments.Where(c => c.Id == id).Select(x => new CommentViewModel()
        {
            Id = x.Id,
            UserId = x.UserId,
            PostId = x.PostId,
            Date = DateTime.Now,
            Text = x.Text,
            CommentId = x.CommentId
        }).ToList();

        /*public void AddComment(CommentViewModel model, string ownerName) 
        {
            
        }*/
        public void Delete(Comments comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}
