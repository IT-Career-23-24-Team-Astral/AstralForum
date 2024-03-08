using System.Drawing;

namespace AstralForum.Data.Entities.Reaction
{
    public class ReactionType : MetadataBaseEntity
    {
        public int ReactionId { get; set; }
        public string ImageUrl { get; set; }
    }
}
