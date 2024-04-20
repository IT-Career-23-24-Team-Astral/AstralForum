using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Reaction
{
    public class ReactionThreadRemovalModel
    {
        public int ReactionThreadId { get; set; }
        public int ThreadId { get; set; }
        public int ReactionTypeId { get; set; }
    }
}