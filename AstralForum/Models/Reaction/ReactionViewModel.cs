using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Reaction
{
    public class ReactionViewModel
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ReactionId { get; set; }
    }
}
