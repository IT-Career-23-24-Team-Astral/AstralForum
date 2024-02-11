using System.ComponentModel.DataAnnotations;

namespace AstralForum.Models
{
    public class ReplyModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ThreadId { get; set; }
        [Required]
        public int CommentId { get; set; }
        public int ReplyId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int CreatedById { get; set; }
        public DateTime Date { get; set; }
    }
}
