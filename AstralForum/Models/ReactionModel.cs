using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models
{
    public class ReactionModel
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int CommentId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ReactionId { get; set; }
    }
}
