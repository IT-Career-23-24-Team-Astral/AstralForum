using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Reaction
{
    public class ReactionThreadModel
    {
        public int ThreadId { get; set; }
        public int ReactionTypeId { get; set; }
    }
}