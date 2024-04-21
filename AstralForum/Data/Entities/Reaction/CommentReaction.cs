using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AstralForum.Data.Entities.Comment;

namespace AstralForum.Data.Entities.Reaction
{
    public class CommentReaction : ReactionBaseEntity
    {
        public int CommentId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Comment.Comment Comment { get; set; }
    }
}