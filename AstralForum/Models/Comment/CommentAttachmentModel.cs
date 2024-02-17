using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models
{
    public class CommentAttachmentModel
    {
        public int Id { get; set; }
        [Required]
        public int CommentId { get; set; }
        [Required]
        public string AttachmentUrl { get; set; }
    }
}