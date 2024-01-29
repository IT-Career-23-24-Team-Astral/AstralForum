using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Reaction
{
    public class ReactionViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        [Required]
        public int ReactionId { get; set; }
    }
}
