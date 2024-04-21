using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstralForum.Data.Entities.Reaction
{
    public class ReactionBaseEntity : MetadataBaseEntity
    {
        public int ReactionTypeId { get; set; }
        public ReactionType ReactionType { get; set; }
    }
}