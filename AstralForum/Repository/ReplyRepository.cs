using AstralForum.Models;
using AstralForum.Repositories;
using AstralForum.Data.Entities.Reply;
using AstralForum.Data.Entities;
using AstralForum.Repository.Interfaces;

namespace AstralForum.Repository
{
    public class ReplyRepository : CommonRepository<Reply>, IReplyRepository
    {
        private readonly ApplicationDbContext context;
        public ReplyRepository(ApplicationDbContext context) : base(context) 
        {
            this.context = context;
        }
        public IEnumerable<ReplyModel> GetRepliesByReplyId(int id) => context.Replies.Where(b => b.ReplyId == id).Select(r => new ReplyModel()
        {
            Id = r.Id,
            ThreadId = r.ThreadId,
            CommentId = r.CommentId,
            Date = DateTime.Now,
            Text = r.Text,
            ReplyId = (int)r.ReplyId

        }).ToList();
        public IEnumerable<ReplyModel> GetRepliesByCommentId(int id) => context.Replies.Where(b => b.CommentId == id).Select(r => new ReplyModel()
        {
            Id = r.Id,
            ThreadId = r.ThreadId,
            CommentId = r.CommentId,
            Date = DateTime.Now,
            Text = r.Text,
            ReplyId = (int)r.ReplyId

        }).ToList();
        public IEnumerable<ReplyModel> GetRepliesByThreadId(int id) => context.Replies.Where(b => b.ThreadId == id).Select(r => new ReplyModel()
        {
            Id = r.Id,
            ThreadId = r.ThreadId,
            CommentId = r.CommentId,
            Date = DateTime.Now,
            Text = r.Text,
            ReplyId = (int)r.ReplyId

        }).ToList();
        public void AddReply(ReplyModel model, User id)
        {
            Reply reply = new Reply()
            {
                Id = model.Id,
                ThreadId = model.ThreadId,
                Text = model.Text,
                CommentId = model.CommentId,
                CreatedBy = id,
            };
            context.Replies.Add(reply);
            context.SaveChanges();
        }

        public void Edit(Reply reply, ReplyModel model)
        {
            reply.Text = model.Text;
            context.Replies.Update(reply);
            context.SaveChanges();
        }
        public void Delete(Reply reply)
        {
            context.Replies.Remove(reply);
            context.SaveChanges();
        }
    }
}