using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Reaction
{
    public class ReactionCommentRemovalModel
    {
        public int ReactionCommentId { get; set; }
        public int CommentId { get; set; }
        public int ReactionTypeId { get; set; }
    }
}