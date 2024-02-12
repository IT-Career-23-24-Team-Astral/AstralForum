using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models
{
    public class CommentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ThreadId { get; set; }
        [Required]
        public string Text { get; set; }
        public int CommentId { get; set; }
        [Required]
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
