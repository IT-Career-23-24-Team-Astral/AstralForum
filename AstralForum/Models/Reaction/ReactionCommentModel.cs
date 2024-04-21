using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Reaction
{
    public class ReactionCommentModel
    {
        public int CommentId { get; set; }
        public int ReactionTypeId { get; set; }
    }
}