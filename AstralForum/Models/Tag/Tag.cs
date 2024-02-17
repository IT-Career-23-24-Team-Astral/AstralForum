using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models.Tag
{
    public class Tag
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ThreadId { get; set; }
        public int CommentId { get; set; }
        [Required]
        public int CreatedById { get; set; }
    }
}
