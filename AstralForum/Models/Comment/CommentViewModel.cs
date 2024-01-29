using Microsoft.Build.Framework;

namespace AstralForum.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Text { get; set; }
        public int? CommentId { get; set; }

    }
}
